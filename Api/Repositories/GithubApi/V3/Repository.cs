using Api.Repositories.GithubApi.Contracts;
using Api.Repositories.GithubApi.V3.Filters;

namespace Api.Repositories.GithubApi.V3;

class Repository : BaseRepository, IRepository
{
    public async Task<IEnumerable<Models.Repository>> Get(RepositoryFilter? filter = null)
    {
        // TODO: Cache dos resultados e parâmetros recebidos
        // TODO: Concluir a filtragem (pós cache)
        var response = await ListEntities<Models.Repository>("orgs/takenet/repos");
        return response;

    }
    public new async Task<IEnumerable<Repository>> ListEntities<Repository>(string path)
    {
        var rawResponse = await base.ListEntities<Repository>(path);

        return rawResponse;
    }

}