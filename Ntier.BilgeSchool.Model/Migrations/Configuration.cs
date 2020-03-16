namespace Ntier.BilgeSchool.Model.Migrations
{
    using Ntier.BilgeSchool.Model.Context;
    using Ntier.BilgeSchool.Model.Entity;
    using Ntier.BilgeSchool.Model.Entity.Enum;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Ntier.BilgeSchool.Model.Context.ProjectContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(ProjectContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            
        }
    }
}
