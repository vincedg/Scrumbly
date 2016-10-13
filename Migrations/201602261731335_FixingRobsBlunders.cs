namespace GScrum.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixingRobsBlunders : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BoardColumns", "DeletedAt", c => c.DateTime());
            AlterColumn("dbo.Boards", "DeletedAt", c => c.DateTime());
            AlterColumn("dbo.Tasks", "DeletedAt", c => c.DateTime());
            AlterColumn("dbo.TaskStickers", "DeletedAt", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TaskStickers", "DeletedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Tasks", "DeletedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Boards", "DeletedAt", c => c.DateTime(nullable: false));
            DropColumn("dbo.BoardColumns", "DeletedAt");
        }
    }
}
