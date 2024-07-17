namespace AutoMarket.DTOs.Response;

public class ModelResponse
{
    public Guid Id { get; set; }

    public string Name { get; set; }
    public int ReleaseYear { get; set; }

    public Guid MakerId { get; set; }
}