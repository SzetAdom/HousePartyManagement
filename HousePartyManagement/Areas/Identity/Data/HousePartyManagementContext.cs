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
    public class HousePartyManagementContext : IdentityDbContext<User>
    {
        public HousePartyManagementContext(DbContextOptions<HousePartyManagementContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {   
            base.OnModelCreating(builder);

            builder.Entity<User>(entity =>
            {

                entity.Property(e => e.Name).HasColumnName("Name");
                entity.Property(e => e.Gender).HasColumnName("Gender");
                entity.Property(e => e.BirthDate).HasColumnName("BirthDate");
                entity.ToTable(name: "User");
                //entity.Propert
            });

            
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
