﻿using API.Dtos;
using API.Dtos.Algorithm;
using API.Dtos.Course;
using API.Dtos.Tag;
using API.Dtos.Visualizations;
using API.Persistence.Entities;
using API.Persistence.UnitOfWork;
using API.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace API.Services.Implementation;

public class VisualizationService(IUnitOfWork wof) : IVisualizationService
{
    private readonly IUnitOfWork _wof = wof;

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
        if (visualization is null) return new ResultWithDataDto<VisualizationDto>(false, default, "Visualization not found");
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
        visualization.Views++;
        await _wof.SaveChangesAsync();
        return new ResultWithDataDto<VisualizationDto>(true, dto, null);
    }
    public async Task<ResultWithDataDto<List<VisualizationDto>>> GetVisualizations(VisualizationFilters filters)
    {
        
        var query = _wof.Visualizations.GetQueryable();

        if (filters.FromDate.HasValue) query = query.Where(x => x.CreatedAt >= filters.FromDate);
        if (filters.ToDate.HasValue) query = query.Where(x => x.CreatedAt <= filters.FromDate);
        if (filters.LikeGreaterThan.HasValue) query = query.Where(x => x.Votes.Count >= filters.LikeGreaterThan);
        if (filters.LikeLessThan.HasValue) query = query.Where(x => x.Votes.Count <= filters.LikeGreaterThan);
        if (filters.ViewCountGreaterThan.HasValue) query = query.Where(x => x.Views >= filters.ViewCountGreaterThan);
        if (filters.ViewCountLessThan.HasValue) query = query.Where(x => x.Views <= filters.ViewCountLessThan);
        if (filters.IsTrending.HasValue) query = OrderByTrend(query);

        var res = await query.Select(x => new VisualizationDto
        {
            Id = x.Id,
            Title = x.Title,
            UserId = x.User.Id,
            UserName = x.User.Username,
            Js = x.Js,
            Css = x.Css,
            Html = x.Html,
            VoteCount = x.Votes.Count,
        }).ToListAsync();
        return new ResultWithDataDto<List<VisualizationDto>>(true, res, null);
    }
    private IQueryable<Visualization> OrderByTrend(IQueryable<Visualization> query)
    {
        int a_views = 15000;
        int b_likes = 200;
        int c_age = 50;

        query = query.OrderByDescending(x => (x.Views / a_views) + (x.Votes.Count * b_likes) + (DateTime.Now - x.CreatedAt).Days / c_age);

        return query;
    }

}
