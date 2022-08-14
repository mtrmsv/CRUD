using CRUD.Domain.Entities.Roles;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Persistance.Configurations
{
    internal class RoleConfiguration : Microsoft.EntityFrameworkCore.IEntityTypeConfiguration<Domain.Entities.Roles.Role>
    {
        public RoleConfiguration() { }
    

        public void Configure(EntityTypeBuilder<Role> builder)
        {
            throw new NotImplementedException();

            builder
                .HasIndex(Current => new { Current.Name })
                .IsUnique(true);

            builder
                .HasMany(Current => Current.Users)
                .WithOne(Other => Other.Role)
                .IsRequired(false)
                .HasForeignKey(Other=>Other.RoleId)
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.NoAction);
        }
    }
}
