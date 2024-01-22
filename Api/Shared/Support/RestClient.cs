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

    public async Task<IEnumerable<T>> List<T>(string path)
    {
        IEnumerable<T> responseBody = [];
        try
        {
            var response = await Client.GetAsync(path);
            responseBody = response.Content.ReadFromJsonAsync<IEnumerable<T>>().Result;
        }
        catch (Exception e)
        {
            Console.WriteLine($"deu ruim", e.Message);
        }
        return responseBody;
    }
}