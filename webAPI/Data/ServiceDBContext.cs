using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using System.Runtime.Serialization;
using webAPI.Entity;
using webAPI.Models;

namespace webAPI.Data
{
    public class ServiceDBContext : DbContext
    {
        public ServiceDBContext(DbContextOptions<ServiceDBContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            foreach (var relationship in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            builder.Ignore<ExtensionDataObject>();

            base.OnModelCreating(builder);
        }

        public DbSet<Users> Users { get; set; }
        public DbSet<Job> Jobs { get; set; }
    }
}
