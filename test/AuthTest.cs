using API.Dtos;
using API.Dtos.Request;
using API.Persistence.Entities;
using API.Persistence.UnitOfWork;
using API.Services.Implementation;
using API.Services.Interface;
using Moq;

public class AuthServiceTests
{
    private readonly Mock<IUnitOfWork> _mockUnitOfWork;
    private readonly Mock<TokenService> _mockTokenService;
    private readonly IAuthService _authService;

    public AuthServiceTests()
    {
        _mockUnitOfWork = new Mock<IUnitOfWork>();
        _mockTokenService = new Mock<TokenService>(null);
        _authService = new AuthService(_mockUnitOfWork.Object, _mockTokenService.Object);
    }

    [Fact]
    public async Task LoginUser_ShouldReturnSuccess_WhenCredentialsAreValid()
    {
        // Arrange
        var dto = new LoginDto("testuser", "password");
        var user = new User { Id = 1, Username = "testuser", Password = BCrypt.Net.BCrypt.HashPassword("password") };
        _mockUnitOfWork.Setup(u => u.Users.GetByUserName(dto.Username)).ReturnsAsync(user);
        _mockTokenService.Setup(t => t.GenerateJwt(It.IsAny<LoggedInUser>())).Returns("token");

        // Act
        var result = await _authService.LoginUser(dto);

        // Assert
        Assert.True(result.IsSuccess);
        Assert.NotNull(result.Data);
        Assert.Equal("token", result.Data.Token);
    }

    [Fact]
    public async Task LoginUser_ShouldReturnFailure_WhenUserNotFound()
    {
        // Arrange
        var dto = new LoginDto("testuser", "password");
        _mockUnitOfWork.Setup(u => u.Users.GetByUserName(dto.Username)).ReturnsAsync((User)null);

        // Act
        var result = await _authService.LoginUser(dto);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Equal("Invalid Username or Password", result.ErrorMessage);
    }

    [Fact]
    public async Task LoginUser_ShouldReturnFailure_WhenPasswordIsInvalid()
    {
        // Arrange
        var dto = new LoginDto("testuser", Password = "wrongpassword");
        var user = new User { Id = 1, Username = "testuser", Password = BCrypt.Net.BCrypt.HashPassword("password") };
        _mockUnitOfWork.Setup(u => u.Users.GetByUserName(dto.Username)).ReturnsAsync(user);

        // Act
        var result = await _authService.LoginUser(dto);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Equal("Invalid Username or Password", result.ErrorMessage);
    }

    [Fact]
    public async Task RegisterAsync_ShouldReturnSuccess_WhenUserIsRegistered()
    {
        // Arrange
        var dto = new RegisterDto("newuser","password");
        _mockUnitOfWork.Setup(u => u.Users.GetByUserName(dto.Username)).ReturnsAsync((User)null);
        _mockUnitOfWork.Setup(u => u.Users.InsertAsync(It.IsAny<User>())).Returns(Task.CompletedTask);
        _mockUnitOfWork.Setup(u => u.SaveChangesAsync()).ReturnsAsync(1);
        _mockTokenService.Setup(t => t.GenerateJwt(It.IsAny<LoggedInUser>())).Returns("token");

        // Act
        var result = await _authService.RegisterAsync(dto);

        // Assert
        Assert.True(result.IsSuccess);
        Assert.NotNull(result.Data);
        Assert.Equal("token", result.Data.Token);
    }

    [Fact]
    public async Task RegisterAsync_ShouldReturnFailure_WhenUsernameAlreadyExists()
    {
        // Arrange
        var dto = new RegisterDto("existinguser","password");
        var existingUser = new User { Id = 1, Username = "existinguser" };
        _mockUnitOfWork.Setup(u => u.Users.GetByUserName(dto.Username)).ReturnsAsync(existingUser);

        // Act
        var result = await _authService.RegisterAsync(dto);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Equal("Username already exists", result.ErrorMessage);
    }
}
