using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RentalMaster.Data;
using RentalMaster.Models;
using RentalMaster.Repositories;
using RentalMaster.ViewModel;

namespace RentalMaster.Controllers
{
    public class RentalItemMakeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IRentalItemMakeRepository _rentalItemMakeRepository;
        private readonly IRentalItemModelRepository _rentalItemModelRepository;

        public RentalItemMakeController(ApplicationDbContext context,
                                        IRentalItemModelRepository rentalItemModelRepository,
                                        IRentalItemMakeRepository rentalItemMakeRepository)
        {
            _context = context;
            _rentalItemMakeRepository = rentalItemMakeRepository;
            _rentalItemModelRepository = rentalItemModelRepository;
        }

        // GET: RentalItemMake
        public async Task<IActionResult> Index()
        {
            return View(_rentalItemMakeRepository.GetAll());
        }

        // GET: RentalItemMake/Details/5
        public async Task<IActionResult> Details(int id)
        {
         
            var rentalItemMake = _rentalItemMakeRepository.GetByID(id);
            if (rentalItemMake == null)
            {
                return NotFound();
            }

            return View(rentalItemMake);
        }

        // GET: RentalItemMake/Create
        public IActionResult Create()
        {
            ViewData["ModelID"] = new SelectList(_rentalItemModelRepository.GetAll(), "ID", "Name");
            return View();
        }

        // POST: RentalItemMake/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name")] RentalItemMake rentalItemMake)
        
        {
            if (ModelState.IsValid)
            {

                _context.Update(rentalItemMake);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            ViewData["ModelID"] = new SelectList(_rentalItemModelRepository.GetAll(), "ID", "Name", rentalItemMake.RentalItemModelID);
            return View(rentalItemMake);
        }

        // GET: RentalItemMake/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var rentalItemMake = _rentalItemMakeRepository.GetByID(id);
            ViewData["ModelID"] = new SelectList(_rentalItemModelRepository.GetAll(), "ID", "Name", rentalItemMake.RentalItemModelID);
            if (rentalItemMake == null)
            {
                return NotFound();
            }
            return View(rentalItemMake);
        }

        // POST: RentalItemMake/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,RentalItemModelID")] RentalItemMake rentalItemMake)
        {
         

            if (ModelState.IsValid)
            {
                //// Find selected Model from the dropdown 
                var selectedModel = _rentalItemModelRepository.GetByID(rentalItemMake.RentalItemModelID);
                selectedModel.MakeID = id;
                _context.Update(selectedModel);
                await _context.SaveChangesAsync();

                // Get current make, with models. 
                rentalItemMake = _rentalItemMakeRepository.GetByID(id); 

                // Is this the first Model added to this Make? Create the list. 
                if (rentalItemMake.RentalItemModels == null)
                    rentalItemMake.RentalItemModels = new List<RentalItemModel>();

                // is this model already added to this make? 
                if (rentalItemMake.RentalItemModels.Any(x => x.ID == selectedModel.ID))
                {
                    ModelState.AddModelError(string.Empty, "Model: " + selectedModel.Name + " is already added");
                    return View(rentalItemMake);
                }

                rentalItemMake.RentalItemModels.Add(selectedModel);

                try
                {
                    _context.Update(rentalItemMake);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RentalItemMakeExists(rentalItemMake.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ModelID"] = new SelectList(_rentalItemModelRepository.GetAll(), "ID", "Name", rentalItemMake.RentalItemModelID);
            return View(rentalItemMake);
        }

        // GET: RentalItemMake/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
   
            var rentalItemMake = _rentalItemMakeRepository.GetByID(id);
            if (rentalItemMake == null)
            {
                return NotFound();
            }

            return View(rentalItemMake);
        }

        // POST: RentalItemMake/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rentalItemMake = _rentalItemMakeRepository.GetByID(id);

            // First remove any models connected to this make. 
            if (rentalItemMake.RentalItemModels != null)
            { 
             rentalItemMake.RentalItemModels.Clear();
             _context.RentalItemMakes.Update(rentalItemMake);
             await _context.SaveChangesAsync();
            }

            // Now delete the make record it self. 
            _context.RentalItemMakes.Remove(rentalItemMake);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
        // GET: RentalItemMake/Remove/5
        public async Task<IActionResult> Remove(int ModelID, int MakeID)
        {
            var removeVM = new RemoveModelVM(); 

            var rentalItemMake = _rentalItemMakeRepository.GetByID(MakeID);
            var rentalItemModel = _rentalItemModelRepository.GetByID(ModelID);

       
            
            if (rentalItemMake == null)
            {
                return NotFound();
            }
            removeVM.MakeID = MakeID;
            removeVM.MakeName = rentalItemMake.Name;
            removeVM.ModelID = ModelID;
            removeVM.ModelName = rentalItemModel.Name;
            return View(removeVM);
        }

        // POST: RentalItemMake/Remove/5
        [HttpPost, ActionName("Remove")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RemoveConfirmed(RemoveModelVM removeVM)
        {
            var MakeID = removeVM.MakeID;
            var modelID = removeVM.ModelID;
            
            var rentalItemMake = _rentalItemMakeRepository.GetByID(MakeID);
            var rentalItemModel = _rentalItemModelRepository.GetByID(modelID);

            if (rentalItemMake.RentalItemModels != null)
            {
                  rentalItemMake.RentalItemModels.RemoveAll(x => x.ID == modelID);

                _context.RentalItemMakes.Update(rentalItemMake);
                await _context.SaveChangesAsync();
            }

           return RedirectToAction(nameof(Index));
        }


        private bool RentalItemMakeExists(int id)
        {
            return _context.RentalItemMakes.Any(e => e.ID == id);
        }
    }
}
