using DevOps.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DevOps.Data
{
    public class AppDbContext : IdentityDbContext<BaseUser>
    {

        private readonly ILoggerFactory _loggerFactory;

        public AppDbContext(DbContextOptions<AppDbContext> options, ILoggerFactory loggerFactory)
                : base(options)
        {
            _loggerFactory = loggerFactory;

        }

        public DbSet<Courses> Courses { get; set; }
        public DbSet<ContactUs> ContactUs { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //Seed User
            SeedData.SeedUserAndRoles(builder,_loggerFactory);
        }


    }
}
