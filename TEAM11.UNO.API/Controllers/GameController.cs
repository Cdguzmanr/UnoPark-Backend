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
    public class GameController : ControllerBase
    {

        private readonly DbContextOptions<UNOEntities> options;
        private readonly ILogger<GameController> logger;

        public GameController(ILogger<GameController> logger, DbContextOptions<UNOEntities> options)
        {
            this.options = options;
            this.logger = logger;
            logger.LogWarning("Game Controller Check");
        }

        /// <summary>
        /// Returns all of the Games.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<Game> Get()
        {
            try
            {
                return new GameManager(options).Load();
            }
            catch (Exception ex)
            {
                StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
                throw;
            }
        }

        /// <summary>
        /// Returns a independent paticular Game.
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}")]
        public Game Get(Guid id)
        {
            try
            {
                return new GameManager(options).LoadById(id);
            }
            catch (Exception ex)
            {
                StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
                throw;
            }

        }

        /// <summary>
        /// Insert a Game.
        /// </summary>
        /// <returns></returns>
        [HttpPost("{rollback?}")]
        public int Post([FromBody] Game game, bool rollback = false)
        {
            try
            {
                return new GameManager(options).Insert(game, rollback);
            }
            catch (Exception ex)
            {
                StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
                throw;
            }
        }

        /// <summary>
        /// Update a Game.
        /// </summary>
        /// <returns></returns>

        [HttpPut("{id}/{rollback?}")]
        public int Put(Guid id, [FromBody] Game game, bool rollback = false)
        {
            try
            {
                return new GameManager(options).Update(game, rollback);
            }
            catch (Exception ex)
            {
                StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
                throw;
            }
        }

        /// <summary>
        /// Delete a Game.
        /// </summary>
        /// <returns></returns>

        [HttpDelete("{id}/{rollback?}")]
        public int Delete(Guid id, bool rollback = false)
        {
            try
            {
                return new GameManager(options).Delete(id, rollback);
            }
            catch (Exception ex)
            {
                StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
                throw;
            }
        }
    }
}
