using Microsoft.EntityFrameworkCore;

namespace MVCLab1.Models
{
    public class AccountModel
    {
        public int ID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public double Balance { get; set; }
    }
}