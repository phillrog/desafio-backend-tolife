using AutoMapper;
using DesafioToLife.Application.DTOs;
using DesafioToLife.Domain.Entities;
using DesafioToLife.Domain.Enums;
using DesafioToLife.Domain.ValueObjects;

namespace DesafioToLife.Application.Mapping
{
    public class DesafioProfile : Profile
    {
        public DesafioProfile() {
            CreateMap<AparelhoDto, Aparelho>().ReverseMap();
            CreateMap<ScheduleDto, Schedule>().ReverseMap();
            CreateMap<LocalidadeDto, Localidade>().ReverseMap();
            CreateMap<Plano, PlanoDto>()
                .ForMember(d => d.Type, opt => opt.MapFrom(s => s.Type.ToString()))
                .ReverseMap()
                .ForMember(d => d.Type, opt => opt.MapFrom(s => Enum.Parse<TipoPlanoEnum>(s.Type, true)));
        }
    }
}
