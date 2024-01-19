using Microsoft.AspNetCore.Mvc;
using Api.Models;
using App.Features.Contracts.Repository;

namespace Api.Controllers
{
    // TODO: (extra): Separação de versão por rota
    // Ex: api.com/v1/repository

    [Route("[controller]")]
    [ApiController]
    public class RepositoryController : ControllerBase
    {
        private readonly IRepositoryListFeature _feature;

        public RepositoryController(IRepositoryListFeature feature)
        {
            _feature = feature;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Repository>>> GetRepositoryItems()
        {
            var repositories = await _feature.GetRepositories().ConfigureAwait(false);

            return Ok(repositories);
        }

    }
}
