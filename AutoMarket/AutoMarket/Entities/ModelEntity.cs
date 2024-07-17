namespace AutoMarket.Entities;

public class ModelEntity
{
    public Guid Id { get; set; }

    public string Name { get; set; } 
    public int ReleaseYear { get; set; }

    public Guid MakerId { get; set; }
    public MakerEntity Maker { get; set; }
}