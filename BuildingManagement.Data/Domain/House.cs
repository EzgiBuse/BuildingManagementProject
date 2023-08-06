using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingManagement.Data.Domain
{
    [Table("House", Schema = "dbo")]
    public class House
    {
        public int HouseID { get; set; }
        public string BlockNo { get; set; }
        public bool Availibility { get; set; }
        public string Type { get; set; }
        public string FloorNo { get; set; }
        public string DoorNo { get; set; }
        public string TenantTC { get; set; }
       
    }

    public class HouseConfiguration : IEntityTypeConfiguration<House>
    {
        public void Configure(EntityTypeBuilder<House> builder)
        {
            builder.Property(x => x.HouseID).IsRequired(true).UseIdentityColumn();
            builder.Property(x => x.BlockNo).IsRequired(true);
            builder.Property(x => x.Availibility).IsRequired(true);
            builder.Property(x => x.FloorNo).IsRequired(true);
            builder.Property(x => x.DoorNo).IsRequired(true);
            


        }
    }


}
