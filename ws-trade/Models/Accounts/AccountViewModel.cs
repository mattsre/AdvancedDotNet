using MVCLab1.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MVCLab1.Models
{
    public class AccountViewModel
    {

        public AccountViewModel(AccountModel account)
        {
            Account = account;
        }
        public AccountModel Account { get; set; }
    }
}