using Microsoft.EntityFrameworkCore;

namespace Api.Models;

public class RepositoryContext : DbContext
{
    public RepositoryContext(DbContextOptions<RepositoryContext> options)
        : base(options)
    {
    }

    public DbSet<Repository> RepositoryItems { get; set; } = null!;
}