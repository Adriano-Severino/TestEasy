using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestEasy.Domain.Models;

namespace TestEasy.Data.Maps
{
    public class RegisterSkillMap : IEntityTypeConfiguration<RegisterSkill>
    {
            public void Configure(EntityTypeBuilder<RegisterSkill> builder)
            {
                builder.ToTable("Skills");
                builder.HasKey(x => x.Id);
                builder.Property(x => x.Knowledge).IsRequired().HasMaxLength(1024).HasColumnType("varchar(1024)");
                builder.Property(x => x.TimeWork).HasMaxLength(50).HasColumnType("varchar(50)");
                builder.Property(x => x.willingnessWorkWeek).HasMaxLength(1024).HasColumnType("varchar(1024)");
                builder.HasOne(x => x.Register).WithMany(x => x.Skills);
        }
        
    }
}
