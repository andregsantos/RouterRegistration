using RouterRegistration.Core.Model;
using RouterRegistration.Core.Repository;
using RouterRegistration.Core.Service;
using System;
using System.Collections.Generic;

namespace RouterRegistration.Services
{
    public class RouteService : IRouteService
    {
        /// <summary>
        /// Private IUnitOfWork Data Member
        /// </summary>
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// NewsService Constructor
        /// </summary>
        /// <param name="unitOfWork">IUnitOfWork</param>
        public RouteService(IUnitOfWork unitOfWork)
        {
            try
            {
                _unitOfWork = unitOfWork;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Route> SearchRoute(string from, string to)
        {
            var routes = _unitOfWork.RouterRepository.GetAllRouters();

            return routes;
        }

        public IEnumerable<Route> GetAllRoutes()
        {
            return _unitOfWork.RouterRepository.GetAllRouters();
        }

    }
}