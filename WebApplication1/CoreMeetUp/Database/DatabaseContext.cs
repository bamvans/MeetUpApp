using CoreMeetUp.Models;
using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;

namespace CoreMeetUp.Database
{
    public  class DatabaseContext : DbContext
    {
        public DbSet<Group> Group { get; set; }
        public DbSet<Person> Person { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Login> Login { get; set; }
        public DbSet<City> City { get; set; }

        public DatabaseContext() : base("MeetUp")
        {
        }

        #region Auto Migration

        class DatabaseConfig : DbMigrationsConfiguration<DatabaseContext>
        {
            public DatabaseConfig()
            {
                AutomaticMigrationsEnabled = true;
                AutomaticMigrationDataLossAllowed = true;
            }
        }

        static DatabaseContext()
        {
            System.Data.Entity.Database.SetInitializer(new MigrateDatabaseToLatestVersion<DatabaseContext, DatabaseConfig>());
        }

        #endregion
    }
}