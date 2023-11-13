using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TestWork.Data;
using TestWork.Models;

namespace TestWork.Controllers
{
    public class CheckTableController : Controller
    {
        private readonly ILogger<CheckTableController> _logger;
        private readonly DataContext _context;

        public CheckTableController(ILogger<CheckTableController> logger, DataContext context)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index(CardModelView obj)
        {
            List<CardModelDataView> results = _context.Cards.Select(c => new CardModelDataView
            {
                CardCode = c.CardCode,
                StartDate = c.StartDate,
                FinishDate = c.FinishDate,
                LastName = c.LastName,
                FirstName = c.FirstName,
                SurName = c.SurName,
                FullName = c.FullName,
                GenderId = c.GenderId,
                Birthday = c.Birthday,
                PhoneHome = c.PhoneHome,
                PhoneMobil = c.PhoneMobil,
                Email = c.Email,
                City = c.City,
                Street = c.Street,
                House = c.House,
                Apartment = c.Apartment,
                AltAddress = c.AltAddress,
                CardType = c.CardType,
                OwnerGUID = c.OwnerGUID,
                CardPer = c.CardPer,
                TurnOver = c.TurnOver
            }).ToList();
            
            obj.Data = results;

            return View(obj);
        }

        public IActionResult ChangeData(CardModelDataView obj) 
        {
            return View(obj);
        }

        [HttpPost]
        public IActionResult SaveData(CardModelDataView obj, string firstName, 
        string lastName, string surname, DateTime birthday) 
        {
            var value = _context.Cards.Where(c => c.CardCode == obj.CardCode).First();
            
            value.FirstName = firstName;
            value.LastName = lastName;
            value.SurName = surname;
            value.Birthday = birthday;

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult CheckCardData(CardModelDataView obj) 
        {
            return View(obj);
        }

        [HttpPost]
        public IActionResult CheckPersonalData(CardModelDataView obj) 
        {
            return View(obj);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}