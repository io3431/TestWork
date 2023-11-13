using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TestWork.Data;
using TestWork.Models;
using System.Xml;

namespace TestWork.Controllers
{
    public class LoadFileController : Controller
    {
        private readonly ILogger<LoadFileController> _logger;
        private readonly DataContext _context;

        public LoadFileController(ILogger<LoadFileController> logger, DataContext context)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UploadXml(CardModelView model)
        {
            if (model.XmlFile != null && model.XmlFile.Length > 0)
            {
                using (var reader = new StreamReader(model.XmlFile.OpenReadStream()))
                {
                    var xmlContent = reader.ReadToEnd();

                    XmlDocument xmlDoc = new();
                    xmlDoc.LoadXml(xmlContent);

                    XmlNodeList cardNodes = xmlDoc.SelectNodes("//Card");

                    foreach (XmlNode cardNode in cardNodes)
                    {
                        CardModel card = new();
                        XmlAttribute cardCodeAttribute = cardNode.Attributes["CARDCODE"]!;

                        card.CardCode = Int64.Parse(cardNode.Attributes["CARDCODE"].Value);
                        card.StartDate = string.IsNullOrEmpty(cardNode.Attributes["STARTDATE"].Value) ?
                            (DateTime?)null : DateTime.Parse(cardNode.Attributes["STARTDATE"].Value);
                        card.FinishDate = string.IsNullOrEmpty(cardNode.Attributes["FINISHDATE"].Value) ?
                            (DateTime?)null : DateTime.Parse(cardNode.Attributes["FINISHDATE"].Value);
                        card.LastName = cardNode.Attributes["LASTNAME"].Value;
                        card.FirstName = cardNode.Attributes["FIRSTNAME"].Value;
                        card.SurName = cardNode.Attributes["SURNAME"].Value;
                        card.FullName = cardNode.Attributes["FULLNAME"].Value;
                        card.GenderId = int.Parse(cardNode.Attributes["GENDERID"].Value);
                        card.Birthday = string.IsNullOrEmpty(cardNode.Attributes["BIRTHDAY"].Value) ?
                            (DateTime?)null : DateTime.Parse(cardNode.Attributes["BIRTHDAY"].Value);
                        card.PhoneHome = cardNode.Attributes["PHONEHOME"].Value;
                        card.PhoneMobil = cardNode.Attributes["PHONEHOME"].Value;
                        card.Email = cardNode.Attributes["EMAIL"].Value;
                        card.City = cardNode.Attributes["CITY"].Value;
                        card.Street = cardNode.Attributes["STREET"].Value;
                        card.House = cardNode.Attributes["HOUSE"].Value;
                        card.Apartment = cardNode.Attributes["APARTMENT"].Value;
                        card.AltAddress = cardNode.Attributes["ALTADDRESS"].Value;
                        card.CardType = cardNode.Attributes["CARDTYPE"].Value;
                        card.OwnerGUID = cardNode.Attributes["OWNERGUID"].Value;
                        card.CardPer = int.Parse(cardNode.Attributes["CARDPER"].Value);
                        card.TurnOver = double.Parse((cardNode.Attributes["TURNOVER"].Value).Replace(".", ","));

                        _context.Cards.Add(card);
                        

                    }

                    _context.SaveChanges();
                }

                ViewBag.Message = "Данные успешно добавлены в базу данных.";
            }

            return View("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}