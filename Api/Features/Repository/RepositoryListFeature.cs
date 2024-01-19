
using Api.Models;
using Api.Repositories.GithubApi.Contracts;
using App.Features.Contracts.Repository;
using Microsoft.EntityFrameworkCore;

namespace Api.Features;

class RepositoryListFeature : IRepositoryListFeature
{
    private readonly RepositoryContext _RepositoriesContext;
    private readonly IRepository _Repository;

    public RepositoryListFeature(RepositoryContext context, IRepository repository)
    {
        _RepositoriesContext = context;
        _Repository = repository;
    }


    //TODO: Receber Parâmetros: Linguagem e paginação
    public async Task<IEnumerable<Repository>> GetRepositories() => await _Repository.GetRepositories();


    // Referência pra gerenciar o cache em memória
    public async Task<Repository> GetRepository(long id)
    {
        var repository = await _RepositoriesContext.RepositoryItems.FindAsync(id);

        if (repository == null)
        {
            // return NotFound();
        }

        return repository;
    }

    public async Task PutRepository(long id, Repository repository)
    {
        if (id != repository.Id)
        {
            // return BadRequest();
        }

        _RepositoriesContext.Entry(repository).State = EntityState.Modified;

        try
        {
            await _RepositoriesContext.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!RepositoryExists(id))
            {
                // return NotFound();
            }
            else
            {
                throw;
            }
        }

        // return NoContent();
    }
    public async Task<Repository> PostRepository(Repository repository)
    {
        _RepositoriesContext.RepositoryItems.Add(repository);
        await _RepositoriesContext.SaveChangesAsync();

        // return CreatedAtAction("GetRepository", new { id = repository.Id }, repository);
        return null;
    }

    public async Task DeleteRepository(long id)
    {
        var repository = await _RepositoriesContext.RepositoryItems.FindAsync(id);
        if (repository == null)
        {
            // return NotFound();
        }

        _RepositoriesContext.RepositoryItems.Remove(repository);
        await _RepositoriesContext.SaveChangesAsync();

        // return NoContent();
    }

    private bool RepositoryExists(long id)
    {
        return _RepositoriesContext.RepositoryItems.Any(e => e.Id == id);
    }
}