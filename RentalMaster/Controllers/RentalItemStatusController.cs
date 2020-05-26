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
    public class RentalItemStatusController : Controller
    {
        private readonly IRentalItemStatusRepository _rentalItemStatusRepository;

        public RentalItemStatusController(IRentalItemStatusRepository rentalItemStatusRepository)
        {
            _rentalItemStatusRepository = rentalItemStatusRepository;
        }
  
        // GET: RentalItemStatus
        public async Task<IActionResult> Index()
        {
            return View(_rentalItemStatusRepository.GetAll());
        }

        // GET: RentalItemStatus/Details/5
        public async Task<IActionResult> Details(int id)
        {

            RentalItemStatus rentalItemStatus = _rentalItemStatusRepository.GetByID(id);
            if (rentalItemStatus == null)
            {
                return NotFound();
            }

            return View(rentalItemStatus);
        }

        // GET: RentalItemStatus/Create
        public IActionResult Create()
        {
            return View();
        }

       
    }
}
