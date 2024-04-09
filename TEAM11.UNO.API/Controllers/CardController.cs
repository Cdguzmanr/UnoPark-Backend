using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TEAM11.UNO.BL;
using TEAM11.UNO.BL.Models;
using TEAM11.UNO.PL.Data;

namespace TEAM11.UNO.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardController : ControllerBase
    {
        private readonly DbContextOptions<UNOEntities> options;
        private readonly ILogger<CardController> logger;

        public CardController(ILogger<CardController> logger, DbContextOptions<UNOEntities> options)
        {
            this.options = options;
            this.logger = logger;
            logger.LogWarning("Card Controller Check");
        }

        [HttpGet]
        public IEnumerable<Card> Get()
        {
            try
            {
                return new CardManager(options).Load();
            }
            catch (Exception ex)
            {
                StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
                throw;
            }
        }

        [HttpGet("{id}")]
        public Card Get(Guid id)
        {
            try
            {
                return new CardManager(options).LoadById(id);
            }
            catch (Exception ex)
            {
                StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
                throw;
            }

        }

        [HttpPost("{rollback?}")]
        public int Post([FromBody] Card card, bool rollback = false)
        {
            try
            {
                return new CardManager(options).Insert(card, rollback);
            }
            catch (Exception ex)
            {
                StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
                throw;
            }
        }

        [HttpPut("{id}/{rollback?}")]
        public int Put(Guid id, [FromBody] Card card, bool rollback = false)
        {
            try
            {
                return new CardManager(options).Update(card, rollback);
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
                return new CardManager(options).Delete(id, rollback);
            }
            catch (Exception ex)
            {
                StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
                throw;
            }
        }
    }
}
