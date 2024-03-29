using Api.Shared.Support;


namespace Api.Repositories.GithubApi.V3.Filters;

public class RepositoryFilter : Filter
{
    public string? language { get; set; }
    public int? per_page { get; set; }
    public int? page { get; set; } = 1;

    public override List<string> LocalParams
    {
        get =>
            new List<string>() { nameof(language) };
    }
}