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

using RentalMaster.ViewModel;

namespace RentalMaster.Controllers
{
    [Authorize]
    public class RentalAgreementController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IRentalItemMakeRepository _rentalItemMakeRepository;
        private readonly IRentalItemModelRepository _rentalItemModelRepository;
        private readonly IRentalItemRepository _rentalItemRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IRentalAgreementRepository _rentalAgreementRepository;

        public RentalAgreementController(ApplicationDbContext context,
                                        IRentalItemModelRepository rentalItemModelRepository,
                                        IRentalItemRepository rentalItemRepository,
                                        ICustomerRepository customerRepository,
                                        IRentalAgreementRepository rentalAgreementRepository,
                                        IRentalItemMakeRepository rentalItemMakeRepository)
        {
            _context = context;
            _customerRepository = customerRepository;
            _rentalItemRepository = rentalItemRepository;
            _rentalItemMakeRepository = rentalItemMakeRepository;
            _rentalItemModelRepository = rentalItemModelRepository;
            _rentalAgreementRepository = rentalAgreementRepository;
        }
        // GET: RentalAgreement
        public async Task<IActionResult> Index(string SearchString)
        {

            if (string.IsNullOrWhiteSpace(SearchString))
            {
                return View(_rentalAgreementRepository.GetAll());
            }
            else
            {
                return View(_rentalAgreementRepository.GetByName(SearchString));
            }

        }

        // GET: RentalAgreement/Details/5
        public async Task<IActionResult> Details(int id)
        {
  

            var rentalAgreement = _rentalAgreementRepository.GetByID(id);
            if (rentalAgreement == null)
            {
                return NotFound();
            }

            return View(rentalAgreement);
        }

        // GET: RentalAgreement/Create
        public IActionResult Create(int? customerID)
        {

            var rentalVM = new RentalAgreementVM();
            var selectableCustomers = _customerRepository.GetAll();

            if (customerID != null)
            {   
                // If CustomerID is passed, preselect that customer in the list. 
                ViewData["CustomerID"] = new SelectList(selectableCustomers, "ID", "FullName", customerID);
            }
            else 
            { 
                ViewData["CustomerID"] = new SelectList(selectableCustomers, "ID", "FullName");
            }

            rentalVM.RentalStartDate = DateTime.Now;
            rentalVM.RentalEndDate = DateTime.Now.AddDays(7);
            rentalVM.RentalReturnedDate = null;

            ViewData["RentalItemID"] = new SelectList(_rentalItemRepository.GetAll(), "ID", "Name");
            return View(rentalVM);
        }

        // POST: RentalAgreement/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RentalAgreementVM rentalAgreementVM)
        {
            var rentalAgreement = new RentalAgreement();
            if (ModelState.IsValid)
            {

                rentalAgreement.RentalStartDate = rentalAgreementVM.RentalStartDate;
                rentalAgreement.RentalEndDate = rentalAgreementVM.RentalEndDate;
                rentalAgreement.RentalReturnedDate = null;
                rentalAgreement.CustomerID = rentalAgreementVM.CustomerID;
                rentalAgreement.Customer = _customerRepository.GetByID(rentalAgreement.CustomerID);
                rentalAgreement.RentalItemID = rentalAgreementVM.RentalItemID;
                rentalAgreement.RentalItem = _rentalItemRepository.GetByID(rentalAgreement.RentalItemID);

         
                _context.Update(rentalAgreement);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            else
            {
                var errors = ModelState.Select(x => x.Value.Errors)
                                       .Where(y => y.Count > 0)
                                       .ToList();
            }
            ViewData["CustomerID"] = new SelectList(_customerRepository.GetAll(), "ID", "FullName", rentalAgreement.CustomerID);
            ViewData["RentalItemID"] = new SelectList(_rentalItemRepository.GetAll(), "ID", "Name", rentalAgreement.RentalItemID);
            return View(rentalAgreement);
        }

        // GET: RentalAgreement/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rentalAgreement = _rentalAgreementRepository.GetByID(id);
            if (rentalAgreement == null)
            {
                return NotFound();
            }
            ViewData["CustomerID"] = new SelectList(_customerRepository.GetAll(), "ID", "FullName", rentalAgreement.CustomerID);
            ViewData["RentalItemID"] = new SelectList(_rentalItemRepository.GetAll(), "ID", "Name", rentalAgreement.RentalItemID);
            return View(rentalAgreement);
        }

        // POST: RentalAgreement/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,RentalStartDate,RentalEndDate,RentalReturnedDate,CustomerID,RentalItemID")] RentalAgreement rentalAgreement)
        {
            if (id != rentalAgreement.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rentalAgreement);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RentalAgreementExists(rentalAgreement.ID))
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
            ViewData["CustomerID"] = new SelectList(_customerRepository.GetAll(), "ID", "FullName", rentalAgreement.CustomerID);
            ViewData["RentalItemID"] = new SelectList(_rentalItemRepository.GetAll(), "ID", "Name", rentalAgreement.RentalItemID);
            return View(rentalAgreement);
        }

        // GET: RentalAgreement/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rentalAgreement = await _context.RentalAgreements
                .Include(r => r.Customer)
                .Include(r => r.RentalItem)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (rentalAgreement == null)
            {
                return NotFound();
            }

            return View(rentalAgreement);
        }

        // POST: RentalAgreement/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rentalAgreement = await _context.RentalAgreements.FindAsync(id);
            _context.RentalAgreements.Remove(rentalAgreement);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RentalAgreementExists(int id)
        {
            return _context.RentalAgreements.Any(e => e.ID == id);
        }
    }
}
