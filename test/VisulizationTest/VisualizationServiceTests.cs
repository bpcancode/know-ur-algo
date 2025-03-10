using API.Dtos;
using API.Dtos.Visualizations;
using API.Persistence.Entities;
using API.Persistence.UnitOfWork;
using API.Services.Implementation;
using API.Services.Interface;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Xunit;

public class VisualizationServiceTests
{
    private readonly Mock<IUnitOfWork> _mockUnitOfWork;
    private readonly IVisualizationService _visualizationService;

    public VisualizationServiceTests()
    {
        _mockUnitOfWork = new Mock<IUnitOfWork>();
        _visualizationService = new VisualizationService(_mockUnitOfWork.Object);
    }

    [Fact]
    public async Task CreateVisualization_ShouldReturnSuccess_WhenAlgorithmAndUserExist()
    {
        // Arrange
        var dto = new VisualizationCreateDto { AlgorithmId = 1, Title = "Test", Js = "js", Html = "html", Css = "css" };
        var userId = 1;
        _mockUnitOfWork.Setup(u => u.Algorithms.FindAsync(dto.AlgorithmId)).ReturnsAsync(new Algorithm());
        _mockUnitOfWork.Setup(u => u.Users.FindAsync(userId)).ReturnsAsync(new User());
        _mockUnitOfWork.Setup(u => u.Visualizations.InsertAsync(It.IsAny<Visualization>())).Returns(Task.CompletedTask);
        _mockUnitOfWork.Setup(u => u.SaveChangesAsync()).ReturnsAsync(1);

        // Act
        var result = await _visualizationService.CreateVisualization(dto, userId);

        // Assert
        Assert.True(result.IsSuccess);
        Assert.Equal("Visualization created successfully", result.ErrorMessage);
    }

    [Fact]
    public async Task CreateVisualization_ShouldReturnFailure_WhenAlgorithmNotFound()
    {
        // Arrange
        var dto = new VisualizationCreateDto { AlgorithmId = 1, Title = "Test", Js = "js", Html = "html", Css = "css" };
        var userId = 1;
        _mockUnitOfWork.Setup(u => u.Algorithms.FindAsync(dto.AlgorithmId)).ReturnsAsync((Algorithm)null);

        // Act
        var result = await _visualizationService.CreateVisualization(dto, userId);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Equal("Algorithm not found", result.ErrorMessage);
    }

    [Fact]
    public async Task CreateVisualization_ShouldReturnFailure_WhenUserNotFound()
    {
        // Arrange
        var dto = new VisualizationCreateDto { AlgorithmId = 1, Title = "Test", Js = "js", Html = "html", Css = "css" };
        var userId = 1;
        _mockUnitOfWork.Setup(u => u.Algorithms.FindAsync(dto.AlgorithmId)).ReturnsAsync(new Algorithm());
        _mockUnitOfWork.Setup(u => u.Users.FindAsync(userId)).ReturnsAsync((User)null);

        // Act
        var result = await _visualizationService.CreateVisualization(dto, userId);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Equal("User not found", result.ErrorMessage);
    }

    [Fact]
    public async Task GetVisualization_ShouldReturnVisualization_WhenFound()
    {
        // Arrange
        var visId = 1;
        var userId = 1;
        var visualization = new Visualization
        {
            Id = visId,
            Title = "Test",
            User = new User { Id = userId, Username = "testuser" },
            Js = "js",
            Html = "html",
            Css = "css",
            Votes = new List<Vote>(),
            Views = 0,
            Algorithm = new Algorithm { Title = "Test Algorithm" }
        };
        _mockUnitOfWork.Setup(u => u.Visualizations.GetQueryable()).Returns(new List<Visualization> { visualization }.AsQueryable());

        // Act
        var result = await _visualizationService.GetVisualization(visId, userId);

        // Assert
        Assert.True(result.IsSuccess);
        Assert.Equal(visId, result.Data.Id);
    }

    [Fact]
    public async Task GetVisualization_ShouldReturnFailure_WhenNotFound()
    {
        // Arrange
        var visId = 1;
        var userId = 1;
        _mockUnitOfWork.Setup(u => u.Visualizations.GetQueryable()).Returns(new List<Visualization>().AsQueryable());

        // Act
        var result = await _visualizationService.GetVisualization(visId, userId);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Equal("Visualization not found", result.ErrorMessage);
    }

    [Fact]
    public async Task GetVisualizations_ShouldReturnFilteredVisualizations()
    {
        // Arrange
        var filters = new VisualizationFilters { FromDate = DateTime.Now.AddDays(-1) };
        var userId = 1;
        var visualizations = new List<Visualization>
        {
            new Visualization
            {
                Id = 1,
                Title = "Test",
                User = new User { Id = userId, Username = "testuser" },
                Js = "js",
                Html = "html",
                Css = "css",
                Votes = new List<Vote>(),
                Views = 0,
                Algorithm = new Algorithm { Title = "Test Algorithm" },
                CreatedAt = DateTime.Now
            }
        };
        _mockUnitOfWork.Setup(u => u.Visualizations.GetQueryable()).Returns(visualizations.AsQueryable());

        // Act
        var result = await _visualizationService.GetVisualizations(filters, userId);

        // Assert
        Assert.True(result.IsSuccess);
        Assert.Single(result.Data);
    }

    [Fact]
    public async Task LikeVisualization_ShouldAddVote_WhenNotVoted()
    {
        // Arrange
        var visId = 1;
        var userId = 1;
        var visualization = new Visualization
        {
            Id = visId,
            Votes = new List<Vote>()
        };
        var user = new User { Id = userId };
        _mockUnitOfWork.Setup(u => u.Visualizations.FindAsync(visId)).ReturnsAsync(visualization);
        _mockUnitOfWork.Setup(u => u.Users.FindAsync(userId)).ReturnsAsync(user);
        _mockUnitOfWork.Setup(u => u.SaveChangesAsync()).ReturnsAsync(1);

        // Act
        var result = await _visualizationService.LikeVisualization(visId, userId);

        // Assert
        Assert.True(result.IsSuccess);
        Assert.Equal("Vote added successfully", result.ErrorMessage);
        Assert.Single(visualization.Votes);
    }

    [Fact]
    public async Task LikeVisualization_ShouldRemoveVote_WhenAlreadyVoted()
    {
        // Arrange
        var visId = 1;
        var userId = 1;
        var vote = new Vote { UserId = userId };
        var visualization = new Visualization
        {
            Id = visId,
            Votes = new List<Vote> { vote }
        };
        var user = new User { Id = userId };
        _mockUnitOfWork.Setup(u => u.Visualizations.FindAsync(visId)).ReturnsAsync(visualization);
        _mockUnitOfWork.Setup(u => u.Users.FindAsync(userId)).ReturnsAsync(user);
        _mockUnitOfWork.Setup(u => u.SaveChangesAsync()).ReturnsAsync(1);

        // Act
        var result = await _visualizationService.LikeVisualization(visId, userId);

        // Assert
        Assert.True(result.IsSuccess);
        Assert.Equal("Vote added successfully", result.ErrorMessage);
        Assert.Empty(visualization.Votes);
    }

    [Fact]
    public async Task LikeVisualization_ShouldReturnFailure_WhenVisualizationNotFound()
    {
        // Arrange
        var visId = 1;
        var userId = 1;
        _mockUnitOfWork.Setup(u => u.Visualizations.FindAsync(visId)).ReturnsAsync((Visualization)null);

        // Act
        var result = await _visualizationService.LikeVisualization(visId, userId);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Equal("Visulization not found", result.ErrorMessage);
    }

    [Fact]
    public async Task LikeVisualization_ShouldReturnFailure_WhenUserNotFound()
    {
        // Arrange
        var visId = 1;
        var userId = 1;
        var visualization = new Visualization { Id = visId };
        _mockUnitOfWork.Setup(u => u.Visualizations.FindAsync(visId)).ReturnsAsync(visualization);
        _mockUnitOfWork.Setup(u => u.Users.FindAsync(userId)).ReturnsAsync((User)null);

        // Act
        var result = await _visualizationService.LikeVisualization(visId, userId);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Equal("User not found", result.ErrorMessage);
    }
}
