using AutoMarket.Repositories.Abstracts;
using AutoMarket.Services.Abstracts;
using AutoMarket.DTOs.Response;
using AutoMarket.DTOs.Request;
using AutoMarket.Entities;
using AutoMapper;

namespace AutoMarket.Services.Bases;

public class CarService(IRepository<MakerEntity> makersRepository, IRepository<ModelEntity> modelRepository, IMapper mapper) : ICarService
{
    private readonly IRepository<MakerEntity> _makersRepository = makersRepository;
    private readonly IRepository<ModelEntity> _modelRepository = modelRepository;
    private readonly IMapper _mapper = mapper;

    #region [ Maker ]

    public async Task<IEnumerable<MakerResponse>> GetAllMakersAsync()
    {
        var makers = await _makersRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<MakerResponse>>(makers);
    }

    public async Task<MakerResponse> GetMakerByIdAsync(Guid id)
    {
        var maker = await _makersRepository.GetByIdAsync(id);
        return _mapper.Map<MakerResponse>(maker);
    }

    public async Task<MakerResponse> AddMakerAsync(CreateMakerRequest request)
    {
        var maker = _mapper.Map<MakerEntity>(request);
        maker.Id = Guid.NewGuid();

        await _makersRepository.AddAsync(maker);
        return _mapper.Map<MakerResponse>(maker);
    }

    public async Task UpdateMakerAsync(UpdateMakerRequest request)
    {
        var maker = _mapper.Map<MakerEntity>(request);
        await _makersRepository.UpdateAsync(maker);
    }

    public async Task DeleteMakerAsync(Guid id)
    {
        await _makersRepository.DeleteAsync(id);
    }

    #endregion

    #region [ Model ]

    public async Task<ModelResponse> GetModelByIdAsync(Guid id)
    {
        var maker = await _modelRepository.GetByIdAsync(id);
        return _mapper.Map<ModelResponse>(maker);
    }

    public async Task UpdateModelAsync(UpdateModelRequest request)
    {
        var model = _mapper.Map<ModelEntity>(request);
        await _modelRepository.UpdateAsync(model);
    }

    public async Task<ModelResponse> AddModelAsync(CreateModelRequest request)
    {
        var model = _mapper.Map<ModelEntity>(request);
        model.Id = Guid.NewGuid();

        await _modelRepository.AddAsync(model);
        return _mapper.Map<ModelResponse>(model);
    }

    public async Task DeleteModelAsync(Guid id)
    {
        await _modelRepository.DeleteAsync(id);
    }

    #endregion
}