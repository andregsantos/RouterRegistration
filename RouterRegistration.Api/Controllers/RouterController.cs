using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RouterRegistration.Core.Service;
using System;

namespace RouterRegistration.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RouterController : ControllerBase
    {
        /// <summary>
        /// IRouterService data member
        /// </summary>
        private readonly IRouterService _routerService;

        private readonly ILogger<RouterController> _logger;

        public RouterController(ILogger<RouterController> logger,
            IRouterService routerService)
        {
            _logger = logger;
            _routerService = routerService;
        }

        public IActionResult GetAllRouters(string from, string to)
        {
            try
            {
                var routers = _routerService.GetAllRouters(from, to);

                return Ok(routers);

            }
            catch (Exception ex)
            {

                _logger.LogError((int)System.Diagnostics.Tracing.EventLevel.Error, ex, ex.Message);

                return NotFound(ex.Message);
            }

        }
    }
}
