using Tarabica15.WebAPI.Common.Logging;

namespace Tarabica15.WebAPI.Business.Managers
{
    public class BaseManager
    {
        private readonly ILogger _logger;

        protected BaseManager(ILogger logger)
        {
            _logger = logger;
        }

        protected ILogger Logger
        {
            get { return _logger; }
        }
    }
}
