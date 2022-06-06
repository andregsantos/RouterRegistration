using RouterRegistration.Core.Model;
using RouterRegistration.Core.Repository;
using RouterRegistration.Core.Service;
using System;
using System.Collections.Generic;

namespace RouterRegistration.Services
{
    public class RouterService : IRouterService
    {
        /// <summary>
        /// Private IUnitOfWork Data Member
        /// </summary>
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// NewsService Constructor
        /// </summary>
        /// <param name="unitOfWork">IUnitOfWork</param>
        public RouterService(IUnitOfWork unitOfWork)
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

        public IEnumerable<Router> GetAllRouters()
        {
            return _unitOfWork.RouterRepository.GetAllRouters();
        }
    }
}
