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
    }
}