using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestWork.Models
{
    public class CardModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Int64 CardCode { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime? StartDate { get; set; } = null;
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime? FinishDate { get; set; } = null;
        [StringLength(50, MinimumLength = 1)]
        public string? LastName { get; set; } = string.Empty;
        [StringLength(50, MinimumLength = 1)]
        public string? FirstName { get; set; } = string.Empty;
        [StringLength(50, MinimumLength = 1)]
        public string? SurName { get; set; } = string.Empty;
        [StringLength(50, MinimumLength = 1)]
        public string? FullName {get; set; } = string.Empty;
        public int GenderId { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime? Birthday { get; set; } = null;
        [StringLength(6, MinimumLength = 1)]
        public string? PhoneHome { get; set; } = string.Empty;
        [StringLength(20, MinimumLength = 11)]
        public string? PhoneMobil { get; set; } = string.Empty;
        [StringLength(300, MinimumLength = 5)]
        public string? Email { get; set; } = string.Empty;
        [StringLength(50, MinimumLength = 1)]
        public string? City { get; set; } = string.Empty;
        [StringLength(100, MinimumLength = 1)]
        public string? Street { get; set; } = string.Empty;
        [StringLength(50, MinimumLength = 1)]
        public string? House { get; set; } = string.Empty;
        [StringLength(50, MinimumLength = 1)]
        public string? Apartment { get; set; } = string.Empty;
        [StringLength(50, MinimumLength = 1)]
        public string? AltAddress { get; set; } = string.Empty;
        [StringLength(50, MinimumLength = 1)]
        public string? CardType { get; set; } = string.Empty;
        [StringLength(100, MinimumLength = 1)]
        public string OwnerGUID { get; set; }
        public int CardPer { get; set; }
        public double TurnOver { get; set; }
    }
}