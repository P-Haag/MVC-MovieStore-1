namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBirthDateToCustomer : DbMigration
    {
        public override void Up()
        {
            //DropColumn("dbo.Customers", "birthdate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "birthdate", c => c.DateTime(nullable: false));
        }
    }
}
