using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DropDownListDemo.Models
{
    public class Contestant
    {
        public int ContestantId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public int CountryId { get; set; }
        public virtual Country Country { get; set; }

    }
}