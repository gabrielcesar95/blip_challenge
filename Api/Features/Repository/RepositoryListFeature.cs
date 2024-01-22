
using Api.Models;
using IApiRepository = Api.Repositories.GithubApi.Contracts.IRepository;
using Api.Repositories.GithubApi.V3.Filters;
using App.Features.Contracts.Repository;

namespace Api.Features;

class RepositoryListFeature : IRepositoryListFeature
{
    private readonly IApiRepository _ApiRepository;

    public RepositoryListFeature(IApiRepository apiRepository)
    {
        _ApiRepository = apiRepository;
    }

    public async Task<IEnumerable<Repository>> ListRepositories(RepositoryFilter? filter)
    {
        // TODO (extra): Salvar/manter os dados num banco local (Api.Repositories.EntityFramework.InMemory)
        var repositoriesFromApi = await _ApiRepository.Get(filter);

        return repositoriesFromApi;
    }

    public async Task<IEnumerable<Repository>> GetRepository() => throw new NotImplementedException();
}