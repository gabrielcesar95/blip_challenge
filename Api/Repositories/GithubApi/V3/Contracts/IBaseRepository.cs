namespace Api.Repositories.GithubApi.V3.Contracts;

using System.Collections.Generic;

public interface IBaseRepository
{
    public Task<IEnumerable<T>> ListEntities<T>(string path);
}