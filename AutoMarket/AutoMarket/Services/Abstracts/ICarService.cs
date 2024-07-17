using AutoMarket.DTOs.Response;
using AutoMarket.DTOs.Request;

namespace AutoMarket.Services.Abstracts;

public interface ICarService
{
    Task<IEnumerable<MakerResponse>> GetAllMakersAsync();

    Task<MakerResponse> AddMakerAsync(CreateMakerRequest request);
    Task UpdateMakerAsync(UpdateMakerRequest request);
    Task<MakerResponse> GetMakerByIdAsync(Guid id);
    Task DeleteMakerAsync(Guid id);

    Task<ModelResponse> AddModelAsync(CreateModelRequest request);
    Task UpdateModelAsync(UpdateModelRequest request);
    Task<ModelResponse> GetModelByIdAsync(Guid id);
    Task DeleteModelAsync(Guid id); 
}
