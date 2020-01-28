using System;
using CarltonsAutoGroupApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CarltonsAutoGroupApi.DBcontext
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Location> Locations { get; set; }
    }
}
