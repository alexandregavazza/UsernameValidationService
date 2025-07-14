using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using UsernameValidationService.Models;

namespace UsernameValidationService.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<UsernameEntry> Usernames => Set<UsernameEntry>();
    }
}
