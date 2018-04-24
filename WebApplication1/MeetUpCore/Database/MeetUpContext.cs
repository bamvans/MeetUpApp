using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Database
{
    public class MeetUpContext : DbContext
    {
        public DbSet<Models.Group> Group { get; set; }
        public DbSet<Models.Person> Person { get; set; }
        public DbSet<Models.Category> Category { get; set; }
        public DbSet<Models.Login> Login { get; set; }
        public DbSet<Models.City> City { get; set; }

        public MeetUpContext() : base("MeetUp")
        {
        }

        #region Auto Migration

        class DatabaseConfig : DbMigrationsConfiguration<MeetUpContext>
        {
            public DatabaseConfig()
            {
                AutomaticMigrationsEnabled = true;
                AutomaticMigrationDataLossAllowed = true;
            }
        }

        static MeetUpContext()
        {
            System.Data.Entity.Database.SetInitializer(new MigrateDatabaseToLatestVersion<MeetUpContext, DatabaseConfig>());
        }

        #endregion
    }
}
