using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using TestEasy.Data.Maps;
using TestEasy.Domain.Models;

namespace TestEasy.Data
{
    public class TestEasyDbContext : DbContext
    {
        public TestEasyDbContext(DbContextOptions<TestEasyDbContext> options) : base(options)
        {
        }
        public DbSet<Register> Registers { get; set; }
        public DbSet<RegisterSkill> RegisterSkills { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new RegisterMap());
            modelBuilder.ApplyConfiguration(new RegisterSkillMap());
        }
    }
}
