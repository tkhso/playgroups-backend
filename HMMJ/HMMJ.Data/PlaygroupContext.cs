using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Playgroup.Data
{
    public class PlaygroupContext : IdentityDbContext<User, IdentityRole<int>, int>
    {
        private readonly DbContextOptions Options;

        public PlaygroupContext(DbContextOptions options)
            : base(options)
        {
            this.Options = options;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
