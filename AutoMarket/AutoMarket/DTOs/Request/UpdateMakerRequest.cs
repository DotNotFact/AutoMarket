namespace AutoMarket.DTOs.Request;

public class UpdateMakerRequest
{
    public Guid Id { get; set; }

    public string Name { get; set; }
    public string Country { get; set; }
    public int FoundedYear { get; set; }
}