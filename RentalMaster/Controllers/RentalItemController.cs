using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RentalMaster.Data;
using RentalMaster.Models;
using RentalMaster.Repositories;

namespace RentalMaster.Controllers
{
    public class RentalItemController : Controller
    {
        private readonly ApplicationDbContext _context;

        private readonly IRentalItemRepository _rentalItemRepository;
        private readonly IRentalItemMakeRepository _rentalItemMakeRepository;
        private readonly IRentalItemModelRepository _rentalItemModelRepository;
        private readonly IRentalItemStatusRepository _rentalItemStatusRepository;


        public RentalItemController(ApplicationDbContext context,
                                    IRentalItemRepository rentalItemRepository,
                                    IRentalItemModelRepository rentalItemModelRepository,
                                    IRentalItemStatusRepository rentalItemStatusRepository,
                                    IRentalItemMakeRepository rentalItemMakeRepository
                                    )
        {
            _context = context;
            _rentalItemRepository = rentalItemRepository;
            _rentalItemModelRepository = rentalItemModelRepository;
            _rentalItemMakeRepository = rentalItemMakeRepository;
            _rentalItemStatusRepository = rentalItemStatusRepository;
        }
        public async Task<IActionResult> Index()
        {
           return View(_rentalItemRepository.GetAll());
        }

        // GET: RentalItem/Details/5
        public async Task<IActionResult> Details(int  id)
        {
 

            var rentalItem = _rentalItemRepository.GetByID(id);
            if (rentalItem == null)
            {
                return NotFound();
            }

            return View(rentalItem);
        }

        // GET: RentalItem/Create
        public IActionResult Create()
        {
            var rentalItem = new RentalItem();
            var makeModelOptions = _rentalItemMakeRepository.MakeModelOptions();
            rentalItem.MakeModelOptions = makeModelOptions.ToList(); 
            ViewData["MakeModelID"] = new SelectList(makeModelOptions, "ID", "Name"); 
            ViewData["StatusID"] = new SelectList(_rentalItemStatusRepository.GetAll(), "ID", "Name");

            rentalItem.Name = RandomRentalItemName();
            
            return View(rentalItem);

        }

        // POST: RentalItem/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,MakeID,ModelID,StatusID,MakeModelID")] RentalItem rentalItem)
        {
            if (ModelState.IsValid)
            {
                var selectedModelMake = _context.MakeModelOptions.FirstOrDefault(p => p.ID == rentalItem.MakeModelID);
                rentalItem.ModelID = selectedModelMake.ModelID;
                rentalItem.MakeID = selectedModelMake.MakeID;
                _context.Add(rentalItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MakeModelID"] = new SelectList(_rentalItemMakeRepository.MakeModelOptions(), "ID", "Name", rentalItem.MakeModelID);
            ViewData["StatusID"] = new SelectList(_rentalItemStatusRepository.GetAll(), "ID", "Name", rentalItem.StatusID);
            return View(rentalItem);
        }

        // GET: RentalItem/Edit/5
        public async Task<IActionResult> Edit(int  id)
        {
            var rentalItem = await _context.RentalItems.FindAsync(id);
            if (rentalItem == null)
            {
                return NotFound();
            }
            ViewData["MakeID"] = new SelectList(_rentalItemMakeRepository.GetAll(), "ID", "Name", rentalItem.MakeID);
            ViewData["ModelID"] = new SelectList(_rentalItemModelRepository.GetAll(), "ID", "Name", rentalItem.ModelID);
            ViewData["StatusID"] = new SelectList(_rentalItemStatusRepository.GetAll(), "ID", "Name", rentalItem.StatusID);
            return View(rentalItem);
        }

        // POST: RentalItem/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,MakeID,ModelID,StatusID")] RentalItem rentalItem)
        {
            if (id != rentalItem.ID)
            {
                return NotFound();
            }
            ViewData["StatusID"] = new SelectList(_rentalItemStatusRepository.GetAll(), "ID", "Name", rentalItem.StatusID);
            ViewData["MakeID"] = new SelectList(_rentalItemMakeRepository.GetAll(), "ID", "Name", rentalItem.MakeID);
            ViewData["ModelID"] = new SelectList(_rentalItemModelRepository.GetAll(), "ID", "Name", rentalItem.ModelID);

            var make = _rentalItemMakeRepository.GetByID(rentalItem.MakeID);
            if (!make.RentalItemModels.Any(x => x.ID == rentalItem.ModelID))
            {
                var model = _rentalItemModelRepository.GetByID(rentalItem.ModelID);

                ModelState.AddModelError(string.Empty, "Model: " + model.Name + " is not valid for this make");
                return View(rentalItem);
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rentalItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RentalItemExists(rentalItem.ID))
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
            ViewData["StatusID"] = new SelectList(_rentalItemStatusRepository.GetAll(), "ID", "Name", rentalItem.StatusID);
            ViewData["MakeID"] = new SelectList(_rentalItemMakeRepository.GetAll(), "ID", "Name", rentalItem.MakeID);
            ViewData["ModelID"] = new SelectList(_rentalItemModelRepository.GetAll(), "ID", "Name", rentalItem.ModelID);
            return View(rentalItem);
        }

        // GET: RentalItem/Delete/5
        public async Task<IActionResult> Delete(int  id)
        {
            var rentalItem = _rentalItemRepository.GetByID(id);
            if (rentalItem == null)
            {
                return NotFound();
            }

            return View(rentalItem);
        }

        // POST: RentalItem/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rentalItem = _rentalItemRepository.GetByID(id);
            _context.RentalItems.Remove(rentalItem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RentalItemExists(int id)
        {
            return _context.RentalItems.Any(e => e.ID == id);
        }
        private string RandomRentalItemName()
        {
            // RentalItemName is random
            Random r = new Random();
            string characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string numbers = "0123456789";
            StringBuilder result = new StringBuilder(6);
            for (int i = 0; i < 3; i++)
            {
                result.Append(characters[r.Next(characters.Length)]);
            }
            for (int i = 0; i < 3; i++)
            {
                result.Append(numbers[r.Next(numbers.Length)]);
            }
            
            return result.ToString();
        }
    }
}
