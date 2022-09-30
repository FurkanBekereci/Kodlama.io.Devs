using Core.Security.Entities;
using Core.Security.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaIoDevs.Persistence.EntityTypeConfigurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users").HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("Id");
            builder.Property(p => p.FirstName).HasColumnName("FirstName");
            builder.Property(p => p.LastName).HasColumnName("LastName");
            builder.Property(p => p.PasswordHash).HasColumnName("PasswordHash");
            builder.Property(p => p.PasswordSalt).HasColumnName("PasswordSalt");
            builder.Property(p => p.Email).HasColumnName("Email");
            builder.Property(p => p.AuthenticatorType).HasColumnName("AuthenticatorType");
            builder.HasMany(u => u.UserOperationClaims);
            builder.HasMany(u => u.RefreshTokens);

            User[] userEntitySeeds = { new(1, "Furkan", "Bekereci", "test@gmail.com", Encoding.ASCII.GetBytes("test"), Encoding.ASCII.GetBytes("test"), true, AuthenticatorType.None) };
            builder.HasData(userEntitySeeds);
        }
    }
}
