using API.Dtos;
using API.Dtos.Algorithm;
using API.Dtos.Course;
using API.Dtos.Tag;
using API.Dtos.Visualizations;
using API.Persistence.Entities;
using API.Persistence.UnitOfWork;
using API.Services.Interface;

namespace API.Services.Implementation;

public class VisualizationService : IVisualizationService
{
    private readonly IUnitOfWork _wof;
    public VisualizationService(IUnitOfWork wof)
    {
        _wof = wof;
    }

    public async Task<ResultDto> CreateVisualization(VisualizationCreateDto dto, int userId)
    {
        var algo = await _wof.Algorithms.FindAsync(dto.AlgorithmId);
        if(algo is null) return new ResultDto(false, "Algorithm not found");

        var user = await _wof.Users.FindAsync(userId);
        if (user is null) return new ResultDto(false, "User not found");

        var visualization = new Visualization
        {
            Algorithm = algo,
            Title = dto.Title,
            User = user,
            CreatedAt = DateTime.Now,
        };

        await _wof.Visualizations.InsertAsync(visualization);
        await _wof.SaveChangesAsync();
        return new ResultDto(true, "Visualization created successfully");
    }

    public async Task<ResultWithDataDto<VisualizationDto>> GetVisualization(int id)
    {
        var visualization = await _wof.Visualizations.FindAsync(id);
        if (visualization is null) return new ResultWithDataDto<VisualizationDto>(false, null, "Visualization not found");
        var dto = new VisualizationDto
        {
            Id = visualization.Id,
            Title = visualization.Title,
            UserId = visualization.User.Id,
            UserName = visualization.User.Username,
            Js = visualization.Js,
            Css = visualization.Css,
            Html = visualization.Html,
            VoteCount = visualization.Votes.Count,
        };
        return new ResultWithDataDto<VisualizationDto>(true, dto, null);
    }

    public async Task<ResultWithDataDto<List<VisualizationDto>>> GetVisualizations()
    {
        var visualizations = await _wof.Visualizations.ListAsync();
        var dtos = visualizations.Select(x => new VisualizationDto
        {
            Id = x.Id,
            Title = x.Title,
            UserId = x.User.Id,
            UserName = x.User.Username,
            Js = x.Js,
            Css = x.Css,
            Html = x.Html,
            VoteCount = x.Votes.Count,
        }).ToList();
        return new ResultWithDataDto<List<VisualizationDto>>(true, dtos, null);
    }

}
