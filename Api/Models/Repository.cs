namespace TodoApi.Models;

public class Repository
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string FullName { get; set; }
    public string? HomePage { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}