using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace MVCLab1.Models
{
    public class StockModel
    {
        public int ID { get; set; }
        [Required]
        [StringLength(5), MinLength(1)]
        public string Ticker { get; set; }
        [Required]
        public string StockName { get; set; }
        [Required]
        [Range(0, 10_000)]
        public double Price { get; set; }
        public string CompanyLogo { get; set; }

    }
}