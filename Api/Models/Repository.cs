namespace Api.Models;

public class Repository
{
    public long id { get; set; }
    public string? name { get; set; }
    public string? full_name { get; set; }
    public string? home_page { get; set; }
    public DateTime created_at { get; set; }
    public DateTime updated_at { get; set; }
}