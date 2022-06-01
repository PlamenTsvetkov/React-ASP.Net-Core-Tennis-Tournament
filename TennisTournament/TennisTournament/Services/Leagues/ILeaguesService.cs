namespace TennisTournament.Services.Leagues
{
    public interface ILeaguesService
    {
        IEnumerable<T> GetAll<T>(int? count = null);
    }
}
