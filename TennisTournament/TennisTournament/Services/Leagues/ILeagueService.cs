namespace TennisTournament.Services.Leagues
{
    using TennisTournament.Data.Models;

    public interface ILeagueService
    {
        IEnumerable<T> GetAll<T>(int? count = null);

        League Create(string name, int surfaceId, int tournamentTypeId);

        Task UpdateAsync(int id, string name, int surfaceId, int tournamentTypeId);

        Task DeleteAsync(int id);
    }
}
