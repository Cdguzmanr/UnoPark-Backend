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
    public class UserController : ControllerBase
    {

        private readonly DbContextOptions<UNOEntities> options;
        private readonly ILogger<UserController> logger;

        public UserController(ILogger<UserController> logger, DbContextOptions<UNOEntities> options)
        {
            this.options = options;
            this.logger = logger;
            logger.LogWarning("Card Controller Check");
        }

        [HttpGet]
        public IEnumerable<User> Get()
        {
            try
            {
                return new UserManager(options).Load();
            }
            catch (Exception ex)
            {
                StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
                throw;
            }
        }

        [HttpGet("{id}")]
        public User Get(Guid id)
        {
            try
            {
                return new UserManager(options).LoadById(id);
            }
            catch (Exception ex)
            {
                StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
                throw;
            }

        }

        [HttpPost("{rollback?}")]
        public int Post([FromBody] User user, bool rollback = false)
        {
            try
            {
                return new UserManager(options).Insert(user, rollback);
            }
            catch (Exception ex)
            {
                StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
                throw;
            }
        }

        [HttpPut("{id}/{rollback?}")]
        public int Put(Guid id, [FromBody] User user, bool rollback = false)
        {
            try
            {
                return new UserManager(options).Update(user, rollback);
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
                return new UserManager(options).Delete(id, rollback);
            }
            catch (Exception ex)
            {
                StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
                throw;
            }
        }

    }
}
