using AutoMarket.DTOs.Response;
using AutoMarket.DTOs.Request;
using AutoMarket.Entities;
using AutoMapper;

namespace AutoMarket.Mappers;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<MakerEntity, MakerResponse>().ReverseMap();
        CreateMap<ModelEntity, ModelResponse>().ReverseMap();

        CreateMap<CreateMakerRequest, MakerEntity>();
        CreateMap<UpdateMakerRequest, MakerEntity>();

        CreateMap<CreateModelRequest, ModelEntity>();
        CreateMap<UpdateModelRequest, ModelEntity>();
    }
}