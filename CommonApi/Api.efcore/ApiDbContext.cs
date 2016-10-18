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

        public DbSet<Feedback> feedbacks { get; set; }

        public DbSet<FeedbackSyscode> feedbacksyscode { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Syscode>().HasKey(sc => new { sc.Category, sc.Key });
            builder.Entity<Feedback>().HasKey(f=>new { f.ID });
            builder.Entity<FeedbackSyscode>().HasKey(fs => new { fs.ID });

            base.OnModelCreating(builder);
        }
    }
}
