using PokeApiNet;
using Pokemon.Services;

namespace Pokemon.Tests;

public class PokemonServiceTests
{
    [Fact]
    public async void Can_Paginate()
    {
        // arrange 
        var client = new PokeApiClient();
        var service = new PokemonService(client) {ItemsPerPage = 5};

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
        var client = new PokeApiClient();
        var service = new PokemonService(client) {ItemsPerPage = 3};

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
        var client = new PokeApiClient();
        var service = new PokemonService(client);

        // act
        var pokemon = await service.Get(-1);

        // assert
        Assert.Null(pokemon);
    }

    [Fact]
    public async void Get_Id_NotExists()
    {
        // arrange
        var client = new PokeApiClient();
        var service = new PokemonService(client);

        // act
        var pokemon = await service.Get(int.MaxValue);

        // assert
        Assert.Null(pokemon);
    }

    [Fact]
    public async void Can_Get_By_Name()
    {
        // arrange
        var client = new PokeApiClient();
        var service = new PokemonService(client);

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
        var client = new PokeApiClient();
        var service = new PokemonService(client);

        // act
        var pokemon = await service.Get(string.Empty);

        // assert
        Assert.Null(pokemon);
    }

    [Fact]
    public async void Get_NameNotExists_ReturnsNull()
    {
        // arrange
        var client = new PokeApiClient();
        var service = new PokemonService(client);

        // act
        var pokemon = await service.Get("chihuahua");

        // assert
        Assert.Null(pokemon);
    }
}