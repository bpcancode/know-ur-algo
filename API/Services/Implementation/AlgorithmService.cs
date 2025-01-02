using API.Dtos;
using API.Dtos.Algorithm;
using API.Persistence.Context;
using API.Persistence.Entities;
using API.Persistence.UnitOfWork;
using API.Services.Interface;
using System.Reflection.Metadata.Ecma335;

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
}
