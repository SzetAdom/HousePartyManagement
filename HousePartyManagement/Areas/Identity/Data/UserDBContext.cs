using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HousePartyManagement.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HousePartyManagement.Data
{
    public class UserDBContext : IdentityDbContext<User>
    {
        public UserDBContext(DbContextOptions<UserDBContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {   
            base.OnModelCreating(builder);

            builder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("idSzemely");
                entity.Property(e => e.UserName).HasColumnName("Felhasznalonev");
                entity.Property(e => e.Name).HasColumnName("Nev");
                entity.Property(e => e.Gender).HasColumnName("Nem");
                entity.Property(e => e.BirthDate).HasColumnName("SzuletesiIdo");
                entity.Property(e => e.PasswordHash).HasColumnName("Jelszo");
                entity.Property(e => e.Email).HasColumnName("Email");


                entity.ToTable(name: "szemely");
                //entity.Propert
            });

            
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
