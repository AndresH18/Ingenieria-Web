using Microsoft.Extensions.Logging;
using Moq;
using PokeApiNet;
using Pokemon.Services;

namespace Pokemon.Tests;

public class LocationsServiceTest
{
    private readonly PokeApiClient _client;

    public LocationsServiceTest()
    {
        _client = new PokeApiClient();
    }

    [Fact]
    public async void Can_GetRegions()
    {
        // arrange 
        var loggerMock = new Mock<ILogger<LocationsService>>();
        var service = new LocationsService(_client, loggerMock.Object);

        // assert
        var result = (await service.GetRegions()).ToArray();

        // assert
        Assert.NotEmpty(result);
        Assert.Equal(10, result.Length);
        Assert.Equal("kanto", result[0]);
    }

    [Fact]
    public async void GetLocations_RegionEmpty_ReturnsEmpty()
    {
        // arrange
        var loggerMock = new Mock<ILogger<LocationsService>>();
        var service = new LocationsService(_client, loggerMock.Object);

        // assert
        var result = await service.GetLocations("");

        // assert
        Assert.NotNull(result);
        Assert.Empty(result.Locations);
    }

    [Theory]
    [InlineData("galar")]
    [InlineData("hisui")]
    public async void GetLocations_RegionHasNoLocations_ReturnsEmpty(string region)
    {
        // arrange
        var loggerMock = new Mock<ILogger<LocationsService>>();
        var service = new LocationsService(_client, loggerMock.Object);

        // assert
        var result = await service.GetLocations(region);

        // assert
        Assert.NotNull(result);
        Assert.Empty(result.Locations);
    }

    [Theory]
    [InlineData("kanto")]
    [InlineData("johto")]
    [InlineData("hoenn")]
    [InlineData("sinnoh")]
    [InlineData("unova")]
    [InlineData("kalos")]
    [InlineData("alola")]
    [InlineData("paldea")]
    public async void GetLocations_RegionHasLocations_ReturnsLocations(string region)
    {
        // arrange
        var loggerMock = new Mock<ILogger<LocationsService>>();
        var service = new LocationsService(_client, loggerMock.Object);

        // assert
        var result = await service.GetLocations(region);

        // assert
        Assert.NotNull(result);
        Assert.NotEmpty(result.Locations);
    }

    [Theory]
    [InlineData("kanto", 2, -1)]
    [InlineData("kanto", 0, 2)]
    [InlineData("", 2, 2)]
    [InlineData("", 0, 2)]
    [InlineData("kanto", 0, -1)]
    [InlineData("", 2, -1)]
    [InlineData("", 0, -1)]
    public async void GetLocations_InvalidParameters_ReturnsNull(string region, int pageSize, int pageOffset)
    {
        // arrange
        var loggerMock = new Mock<ILogger<LocationsService>>();
        var service = new LocationsService(_client, loggerMock.Object);

        // assert
        var result = await service.GetLocations(region, pageSize, pageOffset);

        // assert
        Assert.Null(result);
    }
}