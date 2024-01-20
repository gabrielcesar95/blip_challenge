namespace Api.Repositories.GithubApi.V3.Contracts;

using System.Collections.Generic;
using Api.Shared.Contracts;

public interface IBaseRepository
{
    public Task<IEnumerable<T>> ListEntities<T>(string path, IFilter? filters);

}