using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingManagement.Data.Domain
{
    [Table("Tenant", Schema ="dbo")]
    public class Tenant
    {
        public int TenantID { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string TCNumber { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string VehicleNo { get; set; }
        public double Bills { get; set; }
        public double SubscriptionFee { get; set; }

        

    }

    public class TenantConfiguration : IEntityTypeConfiguration<Tenant>
    {
        public void Configure(EntityTypeBuilder<Tenant> builder)
        {
            builder.Property(x => x.TenantID).IsRequired(true).UseIdentityColumn();
            builder.Property(x => x.Name).IsRequired(true).HasMaxLength(50);
            builder.Property(x => x.LastName).IsRequired(true).HasMaxLength(50);
            builder.Property(x => x.TCNumber).IsRequired(true).HasMaxLength(11);
            builder.Property(x => x.Password).IsRequired(true).HasMaxLength(50);
            builder.Property(x => x.Phone).IsRequired(true).HasMaxLength(13);

            
        }
    }


}
