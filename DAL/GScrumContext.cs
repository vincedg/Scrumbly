using GScrum.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GScrum.DAL
{
    public class GScrumContext : DbContext
    {
        public GScrumContext()
            : base("GScrumContext")
        {
            this.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
        }

        public DbSet<Board> Boards { get; set; }
        public DbSet<BoardColumn> BoardColumns { get; set; }
        public DbSet<Colour> Colours { get; set; }
        public DbSet<Sticker> Stickers { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<TaskSticker> TaskStickers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Task>()
                        .Property(m => m.X_Axis)
                        .HasPrecision(18, 3);

            modelBuilder.Entity<Task>()
                        .Property(m => m.Y_Axis)
                        .HasPrecision(18, 3);

            modelBuilder.Entity<Board>()
                        .Property(m => m.Height)
                        .HasPrecision(18, 3);

            modelBuilder.Entity<Board>()
                        .Property(m => m.Width)
                        .HasPrecision(18, 3);
        }
    }
}