namespace TennisTournament.Services.Players
{
    using TennisTournament.Data.Models;

    public interface IPlayerService
    {
        IEnumerable<T> GetAll<T>(int? count = null);

        Player Create(string name);

        Task UpdateAsync(int id, string name);

        Task DeleteAsync(int id);
    }
}
