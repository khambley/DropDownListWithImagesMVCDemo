using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DropDownListDemo.Models
{
    public class DropDownListDemoDbContext : DbContext
    {
        public DropDownListDemoDbContext() : base("DropDownListDbConnection")
        {

        }
        public DbSet<Contestant> Contestants { get; set; }
        public DbSet<Country> Countries { get; set; }

    }
}