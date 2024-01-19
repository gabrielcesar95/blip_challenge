using Api.Repositories.GithubApi.V3.Contracts;
using Api.Shared.Support;

namespace Api.Repositories.GithubApi.V3;

public class BaseRepository : IBaseRepository
{
    private RestClient Client;
    public BaseRepository()
    {
        //TODO: Jogar essa string pro appSettings
        Client = new RestClient("https://api.github.com", new List<Tuple<string, string>>(){
            Tuple.Create("User-Agent", "blip_challenge.cesdev.com.br")
        });
    }

    public async Task<List<dynamic>> List(string path)
    {
        var response = await Client.List(path);

        return response;
    }
}