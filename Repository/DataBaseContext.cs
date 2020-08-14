using System;
using logMiddlewareProject.Models;
using Microsoft.EntityFrameworkCore;

namespace logMiddlewareProject.Repository
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) :base(options) { }
        public DbSet<log> logs { get; set; }
    }
}
