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
        var service = new PokemonService(client) { ItemsPerPage = 5 };

        // act
        var page1 = (await service.GetPageAsync()).Pokemon.OrderBy(p => p.Id).ToArray();
        var page2 = (await service.GetPageAsync(1)).Pokemon.OrderBy(p => p.Id).ToArray();

        // assert
        Assert.NotEqual(0, page1[0].Id);
        Assert.NotEqual(page1[0].Id, page2[0].Id);
        Assert.Equal(5, page1.Last().Id);
        Assert.Equal(6, page2.First().Id);
    }
}