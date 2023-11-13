using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestWork.Models
{
    public class CardModelView
    {
        public IFormFile XmlFile { get; set; }
        public List<CardModelDataView> Data {get; set; }
        public string SelectedCardCode { get; set; }
    }

    public class CardModelDataView
    {
        public Int64 CardCode { get; set; }
        public DateTime? StartDate { get; set; } = null;
        public DateTime? FinishDate { get; set; } = null;
        public string? LastName { get; set; } = string.Empty;
        public string? FirstName { get; set; } = string.Empty;
        public string? SurName { get; set; } = string.Empty;
        public string? FullName {get; set; } = string.Empty;
        public int GenderId { get; set; }
        public DateTime? Birthday { get; set; } = null;
        public string? PhoneHome { get; set; } = string.Empty;
        public string? PhoneMobil { get; set; } = string.Empty;
        public string? Email { get; set; } = string.Empty;
        public string? City { get; set; } = string.Empty;
        public string? Street { get; set; } = string.Empty;
        public string? House { get; set; } = string.Empty;
        public string? Apartment { get; set; } = string.Empty;
        public string? AltAddress { get; set; } = string.Empty;
        public string? CardType { get; set; } = string.Empty;
        public string OwnerGUID { get; set; }
        public int CardPer { get; set; }
        public double TurnOver { get; set; }
    }
}