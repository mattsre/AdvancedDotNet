using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MVCLab1.Models
{
    public class StockViewModel
    {

        public StockViewModel(AccountModel account, IEnumerable<StockModel> stocks)
        {
            Account = account;
            Stocks = stocks;
        }

        public AccountModel Account { get; set; }
        public IEnumerable<StockModel> Stocks { get; set; }
    }
}