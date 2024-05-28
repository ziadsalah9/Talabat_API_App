using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Models.OrederAggrigation;

namespace Talabat.Repository.Data.Config
{
    public class OrderConfigurations : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.OwnsOne(o => o.ShippingAddress, o => o.WithOwner());
            builder.Property(o => o.Status).HasConversion(
                ostatus => ostatus.ToString(),
                ostatus =>(OrderStatus) Enum.Parse(typeof(OrderStatus),ostatus)
                ) ;
            builder.Property(p=>p.SubTotal).HasColumnType("decimal(18,2)");


            builder.HasOne(p => p.deliveryMethod).WithMany().OnDelete(DeleteBehavior.SetNull);

            


        }
    }
}
