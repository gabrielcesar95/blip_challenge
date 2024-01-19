namespace Api.Repositories.GithubApi.V3.Contracts;

using System.Collections.Generic;
using Api.Repositories.GithubApi.V3.Filters;

public interface IBaseRepository
{
    public Task<IEnumerable<T>> ListEntities<T>(string path, RepositoryFilter? filters);
}