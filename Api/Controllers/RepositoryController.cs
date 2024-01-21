using Microsoft.AspNetCore.Mvc;
using Api.Models;
using App.Features.Contracts.Repository;
using Api.Repositories.GithubApi.V3.Filters;

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
        public async Task<ActionResult<IEnumerable<Repository>>> RepositoriesList(string? language, int? page, int? resultsPerPage)
        {
            var filter = new RepositoryFilter()
            {
                language = language,
                page = page,
                perPage = resultsPerPage
            };

            var repositories = await _feature.ListRepositories(filter);

            return Ok(repositories);
        }

    }
}
