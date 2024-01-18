using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Models;

namespace GithubClient.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RepositoryController : ControllerBase
    {
        private readonly RepositoryContext _context;

        public RepositoryController(RepositoryContext context)
        {
            _context = context;
        }

        // GET: api/Repository
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Repository>>> GetRepositoryItems()
        {
            return await _context.RepositoryItems.ToListAsync();
        }

        // GET: api/Repository/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Repository>> GetRepository(long id)
        {
            var repository = await _context.RepositoryItems.FindAsync(id);

            if (repository == null)
            {
                return NotFound();
            }

            return repository;
        }

        // PUT: api/Repository/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRepository(long id, Repository repository)
        {
            if (id != repository.Id)
            {
                return BadRequest();
            }

            _context.Entry(repository).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RepositoryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Repository
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Repository>> PostRepository(Repository repository)
        {
            _context.RepositoryItems.Add(repository);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRepository", new { id = repository.Id }, repository);
        }

        // DELETE: api/Repository/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRepository(long id)
        {
            var repository = await _context.RepositoryItems.FindAsync(id);
            if (repository == null)
            {
                return NotFound();
            }

            _context.RepositoryItems.Remove(repository);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RepositoryExists(long id)
        {
            return _context.RepositoryItems.Any(e => e.Id == id);
        }
    }
}
