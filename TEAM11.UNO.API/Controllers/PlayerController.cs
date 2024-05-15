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

        /// <summary>
        /// Returns all of the Players.
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Returns a independent paticular Player.
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Insert a Player.
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Update a Player.
        /// </summary>
        /// <returns></returns>

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

        /// <summary>
        /// Delete a Player.
        /// </summary>
        /// <returns></returns>

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
