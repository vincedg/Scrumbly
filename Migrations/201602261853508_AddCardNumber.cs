namespace GScrum.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCardNumber : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tasks", "CardNumber", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tasks", "CardNumber");
        }
    }
}
