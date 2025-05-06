using ConfigurationTool.Common.ConfigurationFactory;
using ConfigurationTool.Common.ConfigurationFactory.Models;
using Microsoft.AspNetCore.Mvc;

namespace ConfigurationTool.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ConfigurationController : ControllerBase
    {
        private readonly ILogger<ConfigurationController> _logger;
        private readonly IConfigurationFactory _configurationFactory;

        public ConfigurationController(ILogger<ConfigurationController> logger,
            IConfigurationFactory configurationFactory)
        {
            _logger = logger;
            _configurationFactory = configurationFactory;
        }

        [HttpGet(Name = "GetConnectionStringSettings")]
        public IActionResult Get()
        {
            var connectionStringSettings = _configurationFactory.GetConfig<ConnectionStrings>();

            return Ok(connectionStringSettings.DefaultConnectionString);
        }
    }
}
