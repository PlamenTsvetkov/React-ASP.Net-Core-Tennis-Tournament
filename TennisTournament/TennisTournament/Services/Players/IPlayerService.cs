namespace TennisTournament.Services.Players
{
    using TennisTournament.Data.Models;

    public interface IPlayerService
    {
        IEnumerable<T> GetAll<T>(int? count = null);

        Player Create(string name);

        bool Update(int id, string name);

        bool Delete(int id);
    }
}
