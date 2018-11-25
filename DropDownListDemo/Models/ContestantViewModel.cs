using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc.Html;

namespace DropDownListDemo.Models
{
    public class ContestantViewModel
    {
        public int ContestantId { get; set; }

        [Required, StringLength(50)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required, StringLength(50)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Range(18D, 105D)]
        public int Age { get; set; }

        [Display(Name = "Home Country")]
        public int CountryId { get; set; }

        public IEnumerable<ImageSelectListItem> AllCountries { get; set; }
    }
}