using Api.Repositories.GithubApi.V3.Filters;

namespace Api.Repositories.EntityFramework.InMemory;

public interface IRepository
{
    Task<Models.Repository> New(Models.Repository repository);
    Task<List<Models.Repository>> Get(RepositoryFilter? filter);

}