using Paket;

namespace TEAM11.UNO.BL
{

    public class LogManager
    {
        protected readonly ILogger logger;
        public LogManager(ILogger logger)
        {
            this.logger = logger;
        }


        public void Log(NuGet.Common.LogMessage message)
        {
            // _logger.LogWarning("{UserId} logged in.", "bfoote");
            logger?.LogInformation(message.Message);

        }
    }
}
