using Api.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using NuGet.Protocol;

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

            var responseBody = response.Content.ReadAsStringAsync().Result;

            if (response.IsSuccessStatusCode)
            {
                var returnedValue = JsonConvert.DeserializeObject<List<dynamic>>(responseBody);
                if (returnedValue is not null)
                {
                    responseValue = returnedValue;
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"deu ruim", e.Message);
        }
        return responseValue;
    }
}