using Microsoft.EntityFrameworkCore;

namespace Api.Models;

public class CacheContext : DbContext
{
    public CacheContext(DbContextOptions<CacheContext> options)
        : base(options)
    {
    }

    public DbSet<Cache> CacheItems { get; set; } = null!;
}