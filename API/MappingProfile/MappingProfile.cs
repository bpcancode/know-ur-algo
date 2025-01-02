using API.Dtos.Visualizations;
using API.Persistence.Entities;
using AutoMapper;

namespace API.MappingProfile;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Visualization, VisualizationDto>()
            .ForMember(dest => dest.VoteCount,
                opt => opt.MapFrom(src => src.Votes.Count));
    }
}
