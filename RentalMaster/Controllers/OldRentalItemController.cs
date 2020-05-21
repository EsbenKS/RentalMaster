//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Rendering;
//using Microsoft.EntityFrameworkCore;
//using RentalMaster.Data;
//using RentalMaster.Models;
//using RentalMaster.Repositories;

//namespace RentalMaster.Controllers
//{
//    public class RentalItemController : Controller
//    {
//        private readonly ApplicationDbContext _context;

//        private readonly IRentalItemModelRepository _rentalItemModelRepository;
//        private readonly IRentalItemMakeRepository _rentalItemMakeRepository;
//        private readonly IRentalItemStatusRepository _rentalItemStatusRepository;


//        public RentalItemController(ApplicationDbContext context,
//                                    IRentalItemModelRepository rentalItemModelRepository,
//                                    IRentalItemStatusRepository rentalItemStatusRepository,
//                                    IRentalItemMakeRepository rentalItemMakeRepository
//                                    )
//        {
//            _context = context;
//            _rentalItemModelRepository = rentalItemModelRepository;
//            _rentalItemMakeRepository = rentalItemMakeRepository;
//             _rentalItemStatusRepository = rentalItemStatusRepository;
//        }
       
//        // GET: RentalItem
//        public async Task<IActionResult> Index()
//        {
//            return View(await _context.RentalItems.ToListAsync());
//         //   var applicationDbContext = _context.RentalItems.Include(r => r.RentalItemMake).Include(r => r.RentalItemModel);
//         //   return View(await applicationDbContext.ToListAsync());
//        }

//        // GET: RentalItem/Details/5
//        public async Task<IActionResult> Details(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var rentalItem = await _context.RentalItems
//                .Include(r => r.RentalItemMake)
//                .Include(r => r.RentalItemModel)
//                .FirstOrDefaultAsync(m => m.ID == id);
//            if (rentalItem == null)
//            {
//                return NotFound();
//            }

//            return View(rentalItem);
//        }

//        // GET: RentalItem/Create
//        public IActionResult Create()
//        {
         
//            ViewData["MakeID"] = new SelectList(_rentalItemMakeRepository.GetAll(), "ID", "Name");
//            ViewData["ModelID"] = new SelectList(_rentalItemModelRepository.GetAll(), "ID", "Name");
//            ViewData["StatusID"] = new SelectList(_rentalItemStatusRepository.GetAll(), "ID", "Name");
//            var rentalItem = new RentalItem();
//            rentalItem.Name = RandomRentalItemName(); 
//            return View(rentalItem);
//        }

//        // POST: RentalItem/Create
 
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Create([Bind("ID,Name,CategoryID,MakeID,ModelID,Status")] RentalItem rentalItem)
//        {
//            if (ModelState.IsValid)
//            {
//                _context.Add(rentalItem);
//                await _context.SaveChangesAsync();
//                return RedirectToAction(nameof(Index));
//            }

//            ViewData["MakeID"] = new SelectList(_rentalItemMakeRepository.GetAll(), "ID", "Name", rentalItem.MakeID);
//            ViewData["ModelID"] = new SelectList(_rentalItemModelRepository.GetAll(), "ID", "Name", rentalItem.ModelID);
//            ViewData["StatusID"] = new SelectList(_rentalItemStatusRepository.GetAll(), "ID", "Name", rentalItem.StatusID);

//            return View(rentalItem);
//        }

//        // GET: RentalItem/Edit/5
//        public async Task<IActionResult> Edit(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var rentalItem = await _context.RentalItems.FindAsync(id);
//            if (rentalItem == null)
//            {
//                return NotFound();
//            }
//            ViewData["StatusID"] = new SelectList(_rentalItemModelRepository.GetAll(), "ID", "Name", rentalItem.StatusID);
//            ViewData["MakeID"]     = new SelectList(_rentalItemMakeRepository.GetAll(), "ID", "Name", rentalItem.MakeID);
//            ViewData["ModelID"]    = new SelectList(_rentalItemStatusRepository.GetAll(), "ID", "Name", rentalItem.ModelID);
//            return View(rentalItem);
//        }

//        // POST: RentalItem/Edit/5
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,MakeID,ModelID,Status")] RentalItem rentalItem)
//        {
//            if (id != rentalItem.ID)
//            {
//                return NotFound();
//            }

//            if (ModelState.IsValid)
//            {
//                try
//                {
//                    _context.Update(rentalItem);
//                    await _context.SaveChangesAsync();
//                }
//                catch (DbUpdateConcurrencyException)
//                {
//                    if (!RentalItemExists(rentalItem.ID))
//                    {
//                        return NotFound();
//                    }
//                    else
//                    {
//                        throw;
//                    }
//                }
//                return RedirectToAction(nameof(Index));
//            }
//            ViewData["StatusID"] = new SelectList(_rentalItemModelRepository.GetAll(), "ID", "Name", rentalItem.StatusID);
//            ViewData["MakeID"] = new SelectList(_rentalItemMakeRepository.GetAll(), "ID", "Name", rentalItem.MakeID);
//            ViewData["ModelID"] = new SelectList(_rentalItemStatusRepository.GetAll(), "ID", "Name", rentalItem.ModelID);
//            return View(rentalItem);
//        }

//        // GET: RentalItem/Delete/5
//        public async Task<IActionResult> Delete(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var rentalItem = await _context.RentalItems
               
//                .Include(r => r.RentalItemMake)
//                .Include(r => r.RentalItemModel)
//                .FirstOrDefaultAsync(m => m.ID == id);
//            if (rentalItem == null)
//            {
//                return NotFound();
//            }

//            return View(rentalItem);
//        }

//        // POST: RentalItem/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> DeleteConfirmed(int id)
//        {
//            var rentalItem = await _context.RentalItems.FindAsync(id);
//            _context.RentalItems.Remove(rentalItem);
//            await _context.SaveChangesAsync();
//            return RedirectToAction(nameof(Index));
//        }

//        private bool RentalItemExists(int id)
//        {
//            return _context.RentalItems.Any(e => e.ID == id);
//        }
//        private string RandomRentalItemName()
//        {
//            // RentalItemName is random
//            Random r = new Random();
//            string characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
//            string numbers = "0123456789";
//            StringBuilder result = new StringBuilder(6);
//            for (int i = 0; i < 3; i++)
//            {
//                result.Append(characters[r.Next(characters.Length)]);
//            }
//            for (int i = 0; i < 3; i++)
//            {
//                result.Append(numbers[r.Next(numbers.Length)]);
//            }
//            return result.ToString();
//        }
//    }
//}
