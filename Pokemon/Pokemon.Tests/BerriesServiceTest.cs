using Microsoft.Extensions.Logging;
using Moq;
using PokeApiNet;
using Pokemon.Services;

namespace Pokemon.Tests;

public class BerriesServiceTest
{
    private readonly PokeApiClient _client;

    public BerriesServiceTest()
    {
        _client = new PokeApiClient();
    }

    [Fact]
    public async void Can_GetAll()
    {
        // arrange
        var loggerMock = new Mock<ILogger<BerriesService>>();
        var service = new BerriesService(_client, loggerMock.Object);
        
        // act
        var result = (await service.GetAll()).ToArray();
        
        // assert
        Assert.NotEmpty(result);
        Assert.Equal("CHERI", result.First().Name);
        Assert.NotEqual(0, result[0].Cost);
    }
    
    [Fact]
    public async void Can_Get_Berries()
    {
        // arrange
        var loggerMock = new Mock<ILogger<BerriesService>>();
        var service = new BerriesService(_client, loggerMock.Object);

        // act
        var result = await service.Get();

        // assert
        Assert.NotNull(result);
        Assert.NotEmpty(result.Results);
        Assert.Equal("cheri", result.Results.First().Name);
    }

    [Fact]
    public async void Get_EmptyString_ReturnsNull()
    {
        // arrange
        var loggerMock = new Mock<ILogger<BerriesService>>();
        var service = new BerriesService(_client, loggerMock.Object);

        // act
        var result = await service.Get(string.Empty);

        // assert
        Assert.Null(result);
    }

    [Fact]
    public async void Get_NameNotExists_ReturnsNull()
    {
        // arrange
        var loggerMock = new Mock<ILogger<BerriesService>>();
        var service = new BerriesService(_client, loggerMock.Object);

        // act
        var result = await service.Get("perrito");

        // assert
        Assert.Null(result);
    }

    [Fact]
    public async void Get_BerryData_NotEmpty()
    {
        // arrange
        var loggerMock = new Mock<ILogger<BerriesService>>();
        var service = new BerriesService(_client, loggerMock.Object);

        // act
        var result = await service.Get("cheri");

        // assert
        Assert.NotNull(result);
        Assert.Equal("cheri", result.BerryName);
        Assert.NotEqual(0, result.BerryId);
        Assert.Equal("cheri-berry", result.ItemName);
        Assert.NotEqual(0, result.ItemId);
    }
}