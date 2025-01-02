using API.Dtos;
using API.Dtos.Visualizations;

namespace API.Services.Interface
{
    public interface IVisualizationService
    {
        public Task<ResultWithDataDto<List<VisualizationDto>>> GetVisualizations();
        public Task<ResultWithDataDto<VisualizationDto>> GetVisualization(int id);
        public Task<ResultDto> CreateVisualization(VisualizationCreateDto dto, int userId);
    }
}
