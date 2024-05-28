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
    internal class OrderItemConfigurations : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.OwnsOne(p => p.OrderWithProduct, p => p.WithOwner());
            builder.Property(p=>p.Price).HasColumnType("decimal(18,2)");
        }
    }
}
