using Microsoft.Extensions.Logging;


namespace EPSS.Repositories
{
    public class BaseRepository
    {
        protected ILogger _logger;

        public BaseRepository(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger(this.GetType().ToString());
        }


    }
}
