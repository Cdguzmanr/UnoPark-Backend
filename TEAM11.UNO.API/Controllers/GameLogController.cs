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
    public class GameLogController : ControllerBase
    {
        private readonly DbContextOptions<UNOEntities> options;
        private readonly ILogger<GameLogController> logger;

        public GameLogController(ILogger<GameLogController> logger, DbContextOptions<UNOEntities> options)
        {
            this.options = options;
            this.logger = logger;
            logger.LogWarning("Game Log Controller Check");
        }

        /// <summary>
        /// Returns all of the Game Logs.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<GameLog> Get()
        {
            try
            {
                return new GameLogManager(options).Load();
            }
            catch (Exception ex)
            {
                StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
                throw;
            }
        }

        /// <summary>
        /// Returns a independent paticular Game Log.
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}")]
        public GameLog Get(Guid id)
        {
            try
            {
                return new GameLogManager(options).LoadById(id);
            }
            catch (Exception ex)
            {
                StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
                throw;
            }

        }

        /// <summary>
        /// Insert a Game Log.
        /// </summary>
        /// <returns></returns>
        [HttpPost("{rollback?}")]
        public int Post([FromBody] GameLog gameLog, bool rollback = false)
        {
            try
            {
                return new GameLogManager(options).Insert(gameLog, rollback);
            }
            catch (Exception ex)
            {
                StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
                throw;
            }
        }

        /// <summary>
        /// Update a Game Log.
        /// </summary>
        /// <returns></returns>
        [HttpPut("{id}/{rollback?}")]
        public int Put(Guid id, [FromBody] GameLog gameLog, bool rollback = false)
        {
            try
            {
                return new GameLogManager(options).Update(gameLog, rollback);
            }
            catch (Exception ex)
            {
                StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
                throw;
            }
        }

        /// <summary>
        /// Delete a Game Log.
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{id}/{rollback?}")]
        public int Delete(Guid id, bool rollback = false)
        {
            try
            {
                return new GameLogManager(options).Delete(id, rollback);
            }
            catch (Exception ex)
            {
                StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
                throw;
            }
        }
    }
}
