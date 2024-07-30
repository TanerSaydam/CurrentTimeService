using CurrentTimeService.Models;
using Microsoft.EntityFrameworkCore;

namespace CurrentTimeService.Context;

public sealed class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Todo> Todos { get; set; }
}
