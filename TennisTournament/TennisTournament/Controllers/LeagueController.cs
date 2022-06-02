namespace TennisTournament.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using TennisTournament.Models.League;
    using TennisTournament.Services.Leagues;

    [Route("api/[controller]")]
    [ApiController]
    public class LeagueController : ControllerBase
    {
        private readonly ILeagueService leaguesService;
        public LeagueController(ILeagueService leaguesService)
        {
            this.leaguesService = leaguesService;
        }


        [HttpGet]
        public JsonResult Get()
        {
            var leaguesService = this.leaguesService.GetAll<AllLeaguesQueryModel>();

            return new JsonResult(leaguesService);
        }

        [HttpPost]
        public JsonResult Post(LeagueFormModel league)
        {

            leaguesService.Create(league.Name, league.SurfaceId, league.TournamentTypeId);

            return new JsonResult("Added Successfully");
        }


        [HttpPut]
        public JsonResult Put(LeagueInputUpdateModel league)
        {
            leaguesService.UpdateAsync(league.Id, league.Name, league.SurfaceId, league.TournamentTypeId);
            return new JsonResult("Updated Successfully");
        }

        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            leaguesService.DeleteAsync(id);

            return new JsonResult("Deleted Successfully");
        }

    }
}
