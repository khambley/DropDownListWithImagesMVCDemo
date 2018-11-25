namespace DropDownListDemo.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using DropDownListDemo.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<DropDownListDemo.Models.DropDownListDemoDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "DropDownListDemo.Models.DropDownListDemoDbContext";
        }

        protected override void Seed(DropDownListDemo.Models.DropDownListDemoDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            context.Countries.AddOrUpdate(x => x.CountryName,
                new Country
                {
                    CountryName = "Germany",
                    ImageFile = "de.png"
                },
                new Country
                {
                    CountryName = "United Kingdom",
                    ImageFile = "gb.png"
                },
                new Country
                {
                    CountryName = "United States",
                    ImageFile = "us.png"
                },
                new Country
                {
                    CountryName = "Samoa",
                    ImageFile = "ws.png"
                }

                );
        }
    }
}
