namespace GScrum.Migrations
{
    using GScrum.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<GScrum.DAL.GScrumContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(GScrum.DAL.GScrumContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            context.Colours.AddOrUpdate(p => p.Name,
                new Colour { Name = "red" },
                new Colour { Name = "blue" },
                new Colour { Name = "green" }, new Colour { Name = "yellow" }, new Colour { Name = "lightblue" }, new Colour { Name = "white" });
        }
    }
}
