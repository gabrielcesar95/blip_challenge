namespace App.Features.Contracts.Repository;

public interface IRepositoryListFeature
{
    Task<IEnumerable<Api.Models.Repository>> GetRepositoriesAsync();
}