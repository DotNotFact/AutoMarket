namespace AutoMarket.DTOs.Response;

public class MakerResponse
{
    public Guid Id { get; set; }

    public string Name { get; set; }
    public string Country { get; set; }
    public int FoundedYear { get; set; }

    public ICollection<ModelResponse> Models { get; set; } = [];
}