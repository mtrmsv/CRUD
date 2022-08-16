using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Persistance.Contexts
{
    public class DataBaseContext: Microsoft.EntityFrameworkCore.DbContext
    {
        public DataBaseContext
            (Microsoft.EntityFrameworkCore.DbContextOptions <DataBaseContext> options) 
            : base(options: options)
        {
            Database.EnsureCreated();
 
        }

        public Microsoft.EntityFrameworkCore.DbSet<CRUD.Domain.Entities.Users.User> Users { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<CRUD.Domain.Entities.Roles.Role> Roles { get; set; }
 


        protected override void OnConfiguring
            (Microsoft.EntityFrameworkCore.DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<CRUD.Domain.Entities.Users.User>()
                .ToTable("Users", t => t.ExcludeFromMigrations());
        }
    }
}
