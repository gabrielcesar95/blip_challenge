namespace Api.Models;

// TODO: Implementar gerenciamento de cache
public class Cache
{
    public long Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime DeleteAt { get; set; }
    public IEnumerable<Repository> Repositories { get; set; }
}