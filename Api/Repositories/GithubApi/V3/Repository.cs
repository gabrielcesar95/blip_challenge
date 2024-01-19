using Api.Models;
using Api.Repositories.GithubApi.Contracts;

namespace Api.Repositories.GithubApi.V3;

class Repository : BaseRepository, IRepository
{
    public async Task<IEnumerable<Models.Repository>> Get()
    {
        var response = await ListEntities<Models.Repository>("orgs/takenet/repos");
        return response;

        // TODO (menor prioridade): Cache dos resultados e parâmetros recebidos
    }
    public new async Task<IEnumerable<Repository>> ListEntities<Repository>(string path)
    {
        var rawResponse = await base.ListEntities<Repository>(path);

        return rawResponse;
    }

}