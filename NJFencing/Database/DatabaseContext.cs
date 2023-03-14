using Microsoft.EntityFrameworkCore;
using NJFencing.Models;

namespace NJFencing.Database;

public class DatabaseContext : DbContext
{
    public DbSet<Account> Accounts { get; set; }

    public DatabaseContext(DbContextOptions options) : base(options)
    {
        
    }
}