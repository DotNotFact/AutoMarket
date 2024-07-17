namespace AutoMarket.DTOs.Request;

public class CreateMakerRequest
{
    public string Name { get; set; }
    public string Country { get; set; }
    public int FoundedYear { get; set; }
}