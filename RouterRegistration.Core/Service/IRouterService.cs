﻿using RouterRegistration.Core.Model;
using System.Collections.Generic;

namespace RouterRegistration.Core.Service
{
    /// <summary>
    /// The IRouterService Inteface describes the implementation required for Routers
    /// </summary>
    public interface IRouterService
    {
        /// <summary>
        /// GetAllEndUsers will return all end Users
        /// </summary>
        /// <returns></returns>
        IEnumerable<Router> GetAllRouters();

    }
}