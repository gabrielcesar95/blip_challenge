using Api.Repositories.GithubApi.V3.Filters;

namespace App.Features.Contracts.Repository;

public interface IRepositoryListFeature
{
    Task<IEnumerable<Api.Models.Repository>> ListRepositories(RepositoryFilter? filter);
}