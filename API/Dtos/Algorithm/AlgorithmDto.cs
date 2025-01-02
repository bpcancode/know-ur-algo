﻿using API.Dtos.Course;
using API.Dtos.Tag;

namespace API.Dtos.Algorithm;

public class AlgorithmDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public CourseDto Courses { get; set; }
    public List<TagDto> Tags = [];
    public int VisualizationsCount { get; set; }
}