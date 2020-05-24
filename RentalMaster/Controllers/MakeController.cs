using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RentalMaster.Data;
using RentalMaster.Models;

namespace RentalMaster.Controllers
{
    public class MakeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MakeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Make
        public async Task<IActionResult> Index()
        {
            return View(await _context.RentalItemMakes.ToListAsync());
        }

        // GET: Make/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rentalItemMake = await _context.RentalItemMakes
                .FirstOrDefaultAsync(m => m.ID == id);
            if (rentalItemMake == null)
            {
                return NotFound();
            }

            return View(rentalItemMake);
        }

        // GET: Make/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Make/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name")] RentalItemMake rentalItemMake)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rentalItemMake);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rentalItemMake);
        }

        // GET: Make/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rentalItemMake = await _context.RentalItemMakes.FindAsync(id);
            if (rentalItemMake == null)
            {
                return NotFound();
            }
            return View(rentalItemMake);
        }

        // POST: Make/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name")] RentalItemMake rentalItemMake)
        {
            if (id != rentalItemMake.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
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
            return View(rentalItemMake);
        }

        // GET: Make/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rentalItemMake = await _context.RentalItemMakes
                .FirstOrDefaultAsync(m => m.ID == id);
            if (rentalItemMake == null)
            {
                return NotFound();
            }

            return View(rentalItemMake);
        }

        // POST: Make/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rentalItemMake = await _context.RentalItemMakes.FindAsync(id);
            _context.RentalItemMakes.Remove(rentalItemMake);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RentalItemMakeExists(int id)
        {
            return _context.RentalItemMakes.Any(e => e.ID == id);
        }
    }
}
