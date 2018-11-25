namespace DropDownListDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCountryProperty : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Contestants", "CountryId");
            AddForeignKey("dbo.Contestants", "CountryId", "dbo.Countries", "CountryId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Contestants", "CountryId", "dbo.Countries");
            DropIndex("dbo.Contestants", new[] { "CountryId" });
        }
    }
}
