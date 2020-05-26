using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RentalMaster.Data;
using RentalMaster.Models;
using RentalMaster.Repositories;

namespace RentalMaster.Controllers
{
    [Authorize]
    public class RentalItemModelController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IRentalItemModelRepository _rentalItemModelRepository;

        public RentalItemModelController(ApplicationDbContext context,
                                        IRentalItemModelRepository rentalItemModelRepository)
        {
            _context = context;
            _rentalItemModelRepository = rentalItemModelRepository;
        }

        // GET: RentalItemModel
        public async Task<IActionResult> Index()
        {
            return View(_rentalItemModelRepository.GetAll());
        }

        // GET: RentalItemModel/Details/5
        public async Task<IActionResult> Details(int id)
        {


            var rentalItemModel = _rentalItemModelRepository.GetByID(id);
            if (rentalItemModel == null)
            {
                return NotFound();
            }

            return View(rentalItemModel);
        }

        // GET: RentalItemModel/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RentalItemModel/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,MakeID")] RentalItemModel rentalItemModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rentalItemModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rentalItemModel);
        }

        // GET: RentalItemModel/Edit/5
        public async Task<IActionResult> Edit(int id)
        {


            var rentalItemModel = _rentalItemModelRepository.GetByID(id);
            if (rentalItemModel == null)
            {
                return NotFound();
            }
            return View(rentalItemModel);
        }

        // POST: RentalItemModel/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,MakeID")] RentalItemModel rentalItemModel)
        {
            if (id != rentalItemModel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rentalItemModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RentalItemModelExists(rentalItemModel.ID))
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
            return View(rentalItemModel);
        }

        // GET: RentalItemModel/Delete/5
        public async Task<IActionResult> Delete(int id)
        {

            var rentalItemModel = _rentalItemModelRepository.GetByID(id);

            if (rentalItemModel == null)
            {
                return NotFound();
            }

            return View(rentalItemModel);
        }

        // POST: RentalItemModel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            var rentalItemModel = _rentalItemModelRepository.GetByID(id);


            if (_rentalItemModelRepository.isModelInUse(id))
            {

                ModelState.AddModelError(string.Empty, "Model is in use. Can't be deleted");
                return View(rentalItemModel);

            }


            _context.RentalItemModels.Remove(rentalItemModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RentalItemModelExists(int id)
        {
            return _context.RentalItemModels.Any(e => e.ID == id);
        }
    }
}
