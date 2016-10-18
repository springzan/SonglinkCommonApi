using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.efcore
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {

        }

        public DbSet<Syscode> syscode { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Syscode>().HasKey(sc => new { sc.Category, sc.Key });
            base.OnModelCreating(builder);
        }
    }
}
