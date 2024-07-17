namespace AutoMarket.DTOs.Request;

public class UpdateModelRequest
{ 
    public Guid Id { get; set; }
    
    public string Name { get; set; }
    public int ReleaseYear { get; set; }

    public Guid MakerId { get; set; }
}