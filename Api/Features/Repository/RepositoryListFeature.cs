
using Api.Models;
using ILocalRepository = Api.Repositories.EntityFramework.InMemory.IRepository;
using IApiRepository = Api.Repositories.GithubApi.Contracts.IRepository;
using Api.Repositories.GithubApi.V3.Filters;
using App.Features.Contracts.Repository;
using Microsoft.EntityFrameworkCore;

namespace Api.Features;

class RepositoryListFeature : IRepositoryListFeature
{
    private readonly IApiRepository _ApiRepository;
    private readonly ILocalRepository _LocalRepository;

    public RepositoryListFeature(IApiRepository apiRepository, ILocalRepository localRepository)
    {
        _ApiRepository = apiRepository;
        _LocalRepository = localRepository;
    }

    public async Task<IEnumerable<Repository>> ListRepositories(RepositoryFilter? filter)
    {
        // TODO (extra): Obter repositórios do Cache
        var repositoriesFromApi = await _ApiRepository.Get(filter);

        //TESTES
        var singleRepo = repositoriesFromApi.FirstOrDefault();
        await _LocalRepository.New(singleRepo);

        return repositoriesFromApi;
    }

    public async Task<IEnumerable<Repository>> GetRepository() => throw new NotImplementedException();
}