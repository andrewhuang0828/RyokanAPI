using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
namespace RyokanAPI.Models

{
    public class RyokanDBContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public RyokanDBContext(DbContextOptions<RyokanDBContext> options, IConfiguration configuration) : base(options)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var connectionString = Configuration.GetConnectionString("RyokanConnection");
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }

        public DbSet<Prefecture> Prefecture { get; set; } = null!;
        public DbSet<Ryokan> Ryokan { get; set; } = null!;
    }
}

