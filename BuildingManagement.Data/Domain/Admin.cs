using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BuildingManagement.Data.Domain
{
    [Table("Admin", Schema = "dbo")]
    public class Admin 
    {
        public int AdminID { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string TCNumber { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }


    }

    public class AdminConfiguration : IEntityTypeConfiguration<Admin>
    {
        public void Configure(EntityTypeBuilder<Admin> builder)
        {
            builder.Property(x => x.AdminID).IsRequired(true).UseIdentityColumn();
            builder.HasIndex(x => x.AdminID).IsUnique(true);
            builder.Property(x => x.Name).IsRequired(true).HasMaxLength(50);
            builder.Property(x => x.LastName).IsRequired(true).HasMaxLength(50);
            builder.Property(x => x.TCNumber).IsRequired(true).HasMaxLength(11);
            builder.Property(x => x.Password).IsRequired(true).HasMaxLength(50);
            builder.Property(x => x.Email).IsRequired(true).HasMaxLength(50);



        }

        
    }


}
