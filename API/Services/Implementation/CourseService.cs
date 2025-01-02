using API.Dtos;
using API.Dtos.Algorithm;
using API.Dtos.Course;
using API.Dtos.Tag;
using API.Persistence.Context;
using API.Persistence.Entities;
using API.Persistence.UnitOfWork;
using API.Services.Interface;
using System.Reflection.Metadata.Ecma335;

namespace API.Services.Implementation;

public class CourseService : ICourseService
{
    private readonly IUnitOfWork _wof;
    public CourseService(IUnitOfWork wof)
    {
        _wof = wof;
    }

    public async Task<ResultWithDataDto<List<CourseDto>>> GetCourses()
    {
        var algorithms = await _wof.Courses.ListAsync();
        var dtos = algorithms.Select(x => new CourseDto
        {
            Id = x.Id,
            Title = x.Title,
            CreditHours = x.CreditHours,
            FullMarks = x.FullMarks,
            IsElective = x.IsElective,
        }).ToList();
        return new ResultWithDataDto<List<CourseDto>>(true, dtos, null);
    }
}
