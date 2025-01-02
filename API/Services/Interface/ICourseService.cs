using API.Dtos.Course;
using API.Dtos;

namespace API.Services.Interface;

public interface ICourseService
{
    Task<ResultWithDataDto<List<CourseDto>>> GetCourses();
}
