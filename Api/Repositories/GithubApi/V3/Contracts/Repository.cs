namespace Api.Repositories.GithubApi.Contracts;

public interface IRepository
{
    Task<IEnumerable<Models.Repository>> GetRepositories();

}