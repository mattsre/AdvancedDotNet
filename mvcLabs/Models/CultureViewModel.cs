using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace mvcLabs.Models
{
    public class CultureViewModel
    {
        public CultureViewModel(CultureInfo[] cultures)
        {
            CulturesList = cultures.Select(c => new SelectListItem()
            {
                Text = c.EnglishName
            });
        }

        public IEnumerable<SelectListItem> CulturesList { get; set; }
    }
}