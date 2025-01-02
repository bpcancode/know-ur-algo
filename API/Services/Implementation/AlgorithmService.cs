using API.Dtos;
using API.Dtos.Algorithm;
using API.Dtos.Course;
using API.Dtos.Tag;
using API.Persistence.Entities;
using API.Persistence.UnitOfWork;
using API.Services.Interface;

namespace API.Services.Implementation;

public class AlgorithmService : IAlgorithmService
{
    private readonly IUnitOfWork _wof;
    public AlgorithmService(IUnitOfWork wof)
    {
        _wof = wof;
    }
    public async Task<ResultDto> CreateDto(AlgorithmCreateDto dto)
    {
        var course = await _wof.Courses.FindAsync(dto.CourseId);
        if (course is null)
        {
            return new ResultDto(false, "Course not found");
        }
        List<Tag> tags = [];
        foreach (var tagId in dto.TagIds)
        {
            var tag = await _wof.Tags.FindAsync(tagId);
            if(tag is null)
            {
                return new ResultDto(false, "Tag not found");
            }
            tags.Add(tag);
        }
        var algorithm = new Algorithm
        {
            Title = dto.Title,
            Course = course,
            Tags = tags,
            
        };
        try
        {
            await _wof.Algorithms.InsertAsync(algorithm);
            await _wof.SaveChangesAsync();
            return new ResultDto(true, "Algorithm created successfully");
        }
        catch (Exception e)
        {
            return new ResultDto(false, e.Message);

        }
    }

    public async Task<ResultWithDataDto<List<AlgorithmDto>>> GetAlgorithms()
    {
        var algorithms = await _wof.Algorithms.ListAsync();
        var dtos = algorithms.Select(x => new AlgorithmDto
        {
           Id = x.Id,
           Title = x.Title,
           Courses = new CourseDto
           {
               Id = x.Course.Id,
               Title = x.Course.Title,
           },
           Tags = x.Tags.Select(tag => new TagDto
           {
               Id = tag.Id,
               Name = tag.Name,
           }).ToList(),
        }).ToList();
        return new ResultWithDataDto<List<AlgorithmDto>>(true, dtos, null);
    }
}
