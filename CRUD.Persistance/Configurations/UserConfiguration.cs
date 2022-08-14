using CRUD.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Persistance.Configurations
{
    internal class UserConfiguration : Microsoft.EntityFrameworkCore.IEntityTypeConfiguration<Domain.Entities.Users.User>
    {
        public UserConfiguration() { }

        public void Configure(EntityTypeBuilder<User> builder)
        {
            throw new NotImplementedException();


            builder
                .HasIndex(Current => new { Current.UserName })
                .IsUnique(true);

            builder
                .HasIndex(Current => new { Current.Email })
                .IsUnique(true);


        }
    }
}
