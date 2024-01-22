using Api.Models;
using Api.Repositories.GithubApi.V3.Filters;
using Microsoft.EntityFrameworkCore;

namespace Api.Repositories.EntityFramework.InMemory;

class Repository : IRepository
{
    private readonly RepositoryContext _RepositoryContext;

    public Repository(RepositoryContext context)
    {
        _RepositoryContext = context;
    }

    public async Task<Models.Repository> New(Models.Repository repository)
    {
        if (_RepositoryContext.Repositories.Where(r => r.id == repository.id).Count() > 0)
        {
            _RepositoryContext.Repositories.Add(repository);
            await _RepositoryContext.SaveChangesAsync();
        }
        return repository;
    }

    public async Task<List<Models.Repository>> Get(RepositoryFilter? filter)
    {
        var repositories = await _RepositoryContext.Repositories.ToListAsync();

        return repositories ?? [];
    }
}