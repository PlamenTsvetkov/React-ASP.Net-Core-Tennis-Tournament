namespace TennisTournament.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using TennisTournament.Models.Player;
    using TennisTournament.Services.Players;

    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly IPlayerService playerservice;
        private readonly IWebHostEnvironment webHostEnvironment;
        public PlayerController(IPlayerService playerservice, IWebHostEnvironment wbHostEnvironment)
        {
            this.playerservice = playerservice;
            this.webHostEnvironment = wbHostEnvironment;
        }


        [HttpGet]
        public JsonResult Get()
        {
            var playerService = this.playerservice.GetAll<AllPlayersQueryModel>();

            return new JsonResult(playerService);
        }

        [HttpPost]
        public JsonResult Post(PlayerFormModel player)
        {

            playerservice.Create(player.Name);

            return new JsonResult("Added Successfully");
        }


        [HttpPut]
        public JsonResult Put(PlayerInputUpdateModel player)
        {
            playerservice.UpdateAsync(player.Id, player.Name);
            return new JsonResult("Updated Successfully");
        }

        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            playerservice.DeleteAsync(id);

            return new JsonResult("Deleted Successfully");
        }

        [Route("SaveFile")]
        [HttpPost]
        public JsonResult SaveFile()
        {
            try
            {
                var httpRequest = Request.Form;
                var postedFile = httpRequest.Files[0];
                string filename = postedFile.FileName;
                var physicalPath = webHostEnvironment.ContentRootPath + "/Photos/" + filename;

                using (var stream = new FileStream(physicalPath, FileMode.Create))
                {
                    postedFile.CopyTo(stream);
                }

                return new JsonResult(filename);
            }
            catch (Exception)
            {

                return new JsonResult("anonymous.png");
            }
        }
    }
}
