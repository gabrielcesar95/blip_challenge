using Api.Repositories.GithubApi.V3.Contracts;
using Api.Shared.Contracts;
using Api.Shared.Support;

namespace Api.Repositories.GithubApi.V3;

public class BaseRepository : IBaseRepository
{
    private RestClient Client;
    public BaseRepository()
    {
        Client = new RestClient("https://api.github.com", new List<Tuple<string, string>>(){
            Tuple.Create("User-Agent", "blip_challenge.cesdev.com.br")
        });
    }

    public async Task<IEnumerable<T>> ListEntities<T>(string path, IFilter? filter = null)
    {
        if (filter is not null)
        {
            path = @$"{path}?{filter.ToQueryString()}";
        }

        var response = await Client.List<T>(path);

        return response;
    }
}