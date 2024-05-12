using TEAM11.UNO.BL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NuGet.Common;
using System.Collections.Generic;
using TEAM11.UNO.BL;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TEAM11.UNO.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogController : ControllerBase
    {

        private readonly ILogger<LogController> logger;

        public LogController(ILogger<LogController> logger)
        {
            this.logger = logger;
        }

        // GET: api/<LogController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<LogController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<LogController>
        [HttpPost]
        public void Post([FromBody] string message)
        {
            // _logger.LogWarning("{UserId} logged in.", "bfoote");
            //_logger.LogInformation(message.Message);
            new LogManager(logger).Log(new LogMessage(NuGet.Common.LogLevel.Warning,
                                                             "User: Test Message:" + message));


        }

        // PUT api/<LogController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<LogController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
