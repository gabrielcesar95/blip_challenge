using Api.Repositories.GithubApi.V3.Filters;

namespace Api.Repositories.GithubApi.Contracts;

public interface IRepository
{
    Task<IEnumerable<Models.Repository>> Get(RepositoryFilter? filter);

}