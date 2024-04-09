using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TEAM11.UNO.BL.Models;
using TEAM11.UNO.BL;
using TEAM11.UNO.PL.Data;

namespace TEAM11.UNO.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {

        private readonly DbContextOptions<UNOEntities> options;
        private readonly ILogger<PlayerController> logger;

        public PlayerController(ILogger<PlayerController> logger, DbContextOptions<UNOEntities> options)
        {
            this.options = options;
            this.logger = logger;
            logger.LogWarning("Player Controller Check");
        }

        [HttpGet]
        public IEnumerable<Player> Get()
        {
            try
            {
                return new PlayerManager(options).Load();
            }
            catch (Exception ex)
            {
                StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
                throw;
            }
        }

        [HttpGet("{id}")]
        public Player Get(Guid id)
        {
            try
            {
                return new PlayerManager(options).LoadById(id);
            }
            catch (Exception ex)
            {
                StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
                throw;
            }

        }

        [HttpPost("{rollback?}")]
        public int Post([FromBody] Player player, bool rollback = false)
        {
            try
            {
                return new PlayerManager(options).Insert(player, rollback);
            }
            catch (Exception ex)
            {
                StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
                throw;
            }
        }

        [HttpPut("{id}/{rollback?}")]
        public int Put(Guid id, [FromBody] Player player, bool rollback = false)
        {
            try
            {
                return new PlayerManager(options).Update(player, rollback);
            }
            catch (Exception ex)
            {
                StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
                throw;
            }
        }

        [HttpDelete("{id}/{rollback?}")]
        public int Delete(Guid id, bool rollback = false)
        {
            try
            {
                return new PlayerManager(options).Delete(id, rollback);
            }
            catch (Exception ex)
            {
                StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
                throw;
            }
        }
    }
}
