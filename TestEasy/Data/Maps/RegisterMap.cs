using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestEasy.Domain.Models;

namespace TestEasy.Data.Maps
{
    public class RegisterMap : IEntityTypeConfiguration<Register>
    {
        public void Configure(EntityTypeBuilder<Register> builder)
        {
            builder.ToTable("Registers");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(120).HasColumnType("varchar(120)");
            builder.Property(x => x.CreateDateTime).IsRequired();
            builder.Property(x => x.Email).IsRequired();
            builder.Property(x => x.Phone).IsRequired().HasMaxLength(30).HasColumnType("varchar(30)");
            builder.Property(x => x.City).IsRequired().HasMaxLength(20).HasColumnType("varchar(20)");
            builder.Property(x => x.State).IsRequired().HasMaxLength(20).HasColumnType("varchar(20)");
        }
    }
} 
