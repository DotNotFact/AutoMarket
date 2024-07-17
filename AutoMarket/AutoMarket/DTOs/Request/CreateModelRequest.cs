namespace AutoMarket.DTOs.Request;

public class CreateModelRequest
{
    public string Name { get; set; }
    public int ReleaseYear { get; set; }

    public Guid MakerId { get; set; }
}