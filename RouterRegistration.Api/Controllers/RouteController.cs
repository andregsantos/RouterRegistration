using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RouterRegistration.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RouterRegistration.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RouteController : ControllerBase
    {
        /// <summary>
        /// IRouterService data member
        /// </summary>
        private readonly IRouteService _routerService;

        private readonly ILogger<RouteController> _logger;

        public RouteController(ILogger<RouteController> logger,
            IRouteService routerService)
        {
            _logger = logger;
            _routerService = routerService;
        }

        [HttpGet("/routes")]
        public IActionResult GetAllRoutes()
        {
            try
            {
                var routers = _routerService.GetAllRoutes();

                return Ok(routers);

            }
            catch (Exception ex)
            {

                _logger.LogError((int)System.Diagnostics.Tracing.EventLevel.Error, ex, ex.Message);

                return NotFound(ex.Message);
            }

        }

        [HttpGet("/router/search/{from}/{to}")]
        public IActionResult SearchRoute(string from, string to)
        {
            try
            {
                var routers = _routerService.SearchRoute(from, to);

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
