using System;
using System.ComponentModel.DataAnnotations;

namespace ImotiWebsite.Models
{
    public class Ad
    {
        public decimal Price { get; set; }
        public DateTime Activated { get; set; }
        public string Agency { get; set; }
        public string Broker { get; set; }
        public string Type { get; set; }
        public int Size { get; set; }
        public string Area { get; set; }
        public string Region { get; set; }
        public string TypeOfAd { get; set; }
        [Key]
        public string URL { get; set; }
    }
}