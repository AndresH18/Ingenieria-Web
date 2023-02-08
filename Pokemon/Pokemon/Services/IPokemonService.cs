namespace Pokemon.Services;

public interface IPokemonService
{
    Task<IEnumerable<string>> GetAllAsync(int offset = 0);
}