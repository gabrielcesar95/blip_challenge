using Api.Repositories.GithubApi.Contracts;
using Api.Repositories.GithubApi.V3.Filters;

namespace Api.Repositories.GithubApi.V3;

class Repository : BaseRepository, IRepository
{
    private string OrgName = "takenet";

    public async Task<IEnumerable<Models.Repository>> Get(RepositoryFilter? filter = null)
    {
        // TODO (extra): Cache dos resultados e parâmetros recebidos
        var response = await ListEntities<Models.Repository>(@$"orgs/{OrgName}/repos", filter);

        // TODO (extra): Tornar a filtragem mais dinâmica
        if (filter?.language is not null)
        {
            var filteredResponse = response.Where(r => r.language == filter.language);
            return filteredResponse;
        }

        return response;
    }

    public new async Task<IEnumerable<Repository>> ListEntities<Repository>(string path, RepositoryFilter? filter)
    {
        var rawResponse = await base.ListEntities<Repository>(path, filter);

        return rawResponse;
    }

}