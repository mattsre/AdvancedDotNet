using Microsoft.EntityFrameworkCore;

namespace MVCLab1.Models
{
    public class StockModel
    {
        public int ID { get; set; }
        public string Ticker { get; set; }
        public string StockName { get; set; }
        public double Price { get; set; }

    }
}