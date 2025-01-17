﻿using Erp_ang2.Models;
using Erp_ang2.Models.Entities;
using IdentityServer4.EntityFramework.Extensions;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Erp_ang2.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        private readonly IOptions<OperationalStoreOptions> _operationalStoreOptions;

        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
            _operationalStoreOptions = operationalStoreOptions;
        }

        public DbSet<User> ListUsers { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<ProjectType> Types { get; set; }
        public DbSet<DbFile> DbFiles { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

           // builder.ApplyConfiguration(new UserConfiguration());

            builder.ConfigurePersistedGrantContext(_operationalStoreOptions.Value);
        }
    }
}
