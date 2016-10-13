namespace GScrum.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixingRobsBlunders2 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.BoardColumns", "BoardId");
            CreateIndex("dbo.Stickers", "ColourId");
            CreateIndex("dbo.Tasks", "ColourId");
            CreateIndex("dbo.TaskStickers", "TaskId");
            CreateIndex("dbo.TaskStickers", "StickerId");
            AddForeignKey("dbo.BoardColumns", "BoardId", "dbo.Boards", "Id", cascadeDelete: false);
            AddForeignKey("dbo.Stickers", "ColourId", "dbo.Colours", "Id", cascadeDelete: false);
            AddForeignKey("dbo.Tasks", "ColourId", "dbo.Colours", "Id", cascadeDelete: false);
            AddForeignKey("dbo.TaskStickers", "StickerId", "dbo.Stickers", "Id", cascadeDelete: false);
            AddForeignKey("dbo.TaskStickers", "TaskId", "dbo.Tasks", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TaskStickers", "TaskId", "dbo.Tasks");
            DropForeignKey("dbo.TaskStickers", "StickerId", "dbo.Stickers");
            DropForeignKey("dbo.Tasks", "ColourId", "dbo.Colours");
            DropForeignKey("dbo.Stickers", "ColourId", "dbo.Colours");
            DropForeignKey("dbo.BoardColumns", "BoardId", "dbo.Boards");
            DropIndex("dbo.TaskStickers", new[] { "StickerId" });
            DropIndex("dbo.TaskStickers", new[] { "TaskId" });
            DropIndex("dbo.Tasks", new[] { "ColourId" });
            DropIndex("dbo.Stickers", new[] { "ColourId" });
            DropIndex("dbo.BoardColumns", new[] { "BoardId" });
        }
    }
}
