using Microsoft.Extensions.Logging;
using Moq;
using PokeApiNet;
using Pokemon.Services;

namespace Pokemon.Tests;

public class PokemonServiceTests
{
    private readonly PokeApiClient _client;

    public PokemonServiceTests()
    {
        _client = new PokeApiClient();
    }

    [Fact]
    public async void Can_Paginate()
    {
        // arrange 
        var logMock = new Mock<ILogger<PokemonService>>();
        var service = new PokemonService(_client, logMock.Object) {ItemsPerPage = 5};

        // act
        var page1 = (await service.GetPageAsync()).Pokemon.OrderBy(p => p.Id).ToArray();
        var page2 = (await service.GetPageAsync(1)).Pokemon.OrderBy(p => p.Id).ToArray();

        // assert
        Assert.NotEqual(0, page1[0].Id);
        Assert.NotEqual(page1[0].Id, page2[0].Id);
        Assert.Equal(5, page1.Last().Id);
        Assert.Equal(6, page2.First().Id);
    }

    [Fact]
    public async void Can_Get_By_Id()
    {
        // arrange
        var logMock = new Mock<ILogger<PokemonService>>();
        var service = new PokemonService(_client, logMock.Object) {ItemsPerPage = 3};

        // act 
        var pokemon = await service.Get(145);

        // assert
        Assert.NotNull(pokemon);
        Assert.False(string.IsNullOrWhiteSpace(pokemon.Name));
    }

    [Fact]
    public async void Get_NegativeNumber_ReturnsNull()
    {
        // arrange
        var logMock = new Mock<ILogger<PokemonService>>();
        var service = new PokemonService(_client, logMock.Object);

        // act
        var pokemon = await service.Get(-1);

        // assert
        Assert.Null(pokemon);
    }

    [Fact]
    public async void Get_Id_NotExists()
    {
        // arrange
        var logMock = new Mock<ILogger<PokemonService>>();
        var service = new PokemonService(_client, logMock.Object);

        // act
        var pokemon = await service.Get(int.MaxValue);

        // assert
        Assert.Null(pokemon);
    }

    [Fact]
    public async void Can_Get_By_Name()
    {
        // arrange
        var logMock = new Mock<ILogger<PokemonService>>();
        var service = new PokemonService(_client, logMock.Object);

        // act
        var pokemon = await service.Get("lucario");

        // assert
        Assert.NotNull(pokemon);
        Assert.False(string.IsNullOrWhiteSpace(pokemon.Name));
    }

    [Fact]
    public async void Get_Blank_ReturnsNull()
    {
        // arrange
        var logMock = new Mock<ILogger<PokemonService>>();
        var service = new PokemonService(_client, logMock.Object);

        // act
        var pokemon = await service.Get(string.Empty);

        // assert
        Assert.Null(pokemon);
    }

    [Fact]
    public async void Get_NameNotExists_ReturnsNull()
    {
        // arrange
        var logMock = new Mock<ILogger<PokemonService>>();
        var service = new PokemonService(_client, logMock.Object);

        // act
        var pokemon = await service.Get("perrito");

        // assert
        Assert.Null(pokemon);
    }
}