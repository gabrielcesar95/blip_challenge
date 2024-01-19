namespace Api.Repositories.GithubApi.V3.Contracts;

using System.Collections.Generic;

public interface IBaseRepository
{
    public Task<List<dynamic>> List(string path);
}