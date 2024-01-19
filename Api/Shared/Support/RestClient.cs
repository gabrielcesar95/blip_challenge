namespace Api.Shared.Support;

public class RestClient
{
    private static HttpClient Client;

    public RestClient(string uri, List<Tuple<string, string>>? defaultHeaders = null)
    {
        Client = new() { BaseAddress = new Uri(uri) };

        if (defaultHeaders is not null)
        {
            foreach (var header in defaultHeaders)
            {
                Client.DefaultRequestHeaders.Add(header.Item1, header.Item2);
            }
        }

    }

    public async Task<List<dynamic>> List(string path)
    {
        List<dynamic> responseValue = [];
        try
        {
            var response = await Client.GetAsync(path);
            var responseBody = response.Content.ReadFromJsonAsync<IEnumerable<dynamic>>().Result; // TODO: Substituir esse Dynamic oor um generic type
        }
        catch (Exception e)
        {
            Console.WriteLine($"deu ruim", e.Message);
        }
        return responseValue;
    }
}