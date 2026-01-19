using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Idntity;
using DataAccess.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Data
{
    public class Context : IdentityDbContext<ApplicationUser>
    {
        //to inject DB
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }
        //Dbset for models
        public DbSet<FileApproval> FileApprovals { get; set; }
        public DbSet<FileMetadata> FileMetadatas { get; set; }
        //Calling Configruation files & seeding data
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(Context).Assembly);
        }

    }
}
