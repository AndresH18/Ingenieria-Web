using Moq;
using Pokemon.Services;

namespace Pokemon.Tests;

public class PokemonServiceTests
{
    [Fact]
    public async void Can_GetAllAsync()
    {
        // arrange
        var list = new List<string>()
        {
            "Pikachu", "Charizar", "Lucario"
        };

        var mock = new Mock<IPokemonService>();
        mock.Setup(m => m.GetAllAsync(It.IsAny<int>())).ReturnsAsync(list);

        var service = mock.Object;
        // act
        var result = (await service.GetAllAsync()).ToArray();

        // assert
        Assert.NotNull(result);
        Assert.NotEmpty(result);
        Assert.True(result.Length == list.Count);
        for (var i = 0; i < list.Count; i++)
        {
            Assert.Equal(result[i], list[i]);
        }
    }
}