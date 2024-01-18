
using Api.Models;
using App.Features.Contracts.Repository;
using Microsoft.EntityFrameworkCore;

namespace Api.Features;

class RepositoryListFeature : IRepositoryListFeature
{
    private readonly RepositoryContext _context;

    public RepositoryListFeature(RepositoryContext context)
    {
        _context = context;
    }


    //TODO: Receber Parâmetros: Linguagem e paginação
    public async Task<IEnumerable<Repository>> GetRepositoriesAsync()
    {
        return await _context.RepositoryItems.ToListAsync();
    }

    // public async Task<ActionResult<IEnumerable<Repository>>> GetRepositoryItems()
    // {
    //     return await _feature.GetRepositoriesAsync();
    // }

    // public async Task<ActionResult<Repository>> GetRepository(long id)
    // {
    //     var repository = await _context.RepositoryItems.FindAsync(id);

    //     if (repository == null)
    //     {
    //         return NotFound();
    //     }

    //     return repository;
    // }

    // public async Task<IActionResult> PutRepository(long id, Repository repository)
    // {
    //     if (id != repository.Id)
    //     {
    //         return BadRequest();
    //     }

    //     _context.Entry(repository).State = EntityState.Modified;

    //     try
    //     {
    //         await _context.SaveChangesAsync();
    //     }
    //     catch (DbUpdateConcurrencyException)
    //     {
    //         if (!RepositoryExists(id))
    //         {
    //             return NotFound();
    //         }
    //         else
    //         {
    //             throw;
    //         }
    //     }

    //     return NoContent();
    // }
    // public async Task<ActionResult<Repository>> PostRepository(Repository repository)
    // {
    //     _context.RepositoryItems.Add(repository);
    //     await _context.SaveChangesAsync();

    //     return CreatedAtAction("GetRepository", new { id = repository.Id }, repository);
    // }

    // public async Task<IActionResult> DeleteRepository(long id)
    // {
    //     var repository = await _context.RepositoryItems.FindAsync(id);
    //     if (repository == null)
    //     {
    //         return NotFound();
    //     }

    //     _context.RepositoryItems.Remove(repository);
    //     await _context.SaveChangesAsync();

    //     return NoContent();
    // }

    // private bool RepositoryExists(long id)
    // {
    //     return _context.RepositoryItems.Any(e => e.Id == id);
    // }
}