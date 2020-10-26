using InfrastructureLayer.DataTransferObjects;
using InfrastructureLayer.Interfaces.BusinessLogic;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly ILogger<MainBusinessLogic> _log;

        public EmployeeService(ILogger<MainBusinessLogic> log)
        {
            _log = log;
        }

        public EmployeeDTO InsertNames(string Firstname, string LastName)
        {
            try
            {
                EmployeeDTO Response = new EmployeeDTO
                {
                    FirstName = Firstname,
                    LastName = LastName
                };

                return Response;
            }
            catch (Exception ex)
            {
                _log.LogError(ex, "");
                throw ex;
            }
        }
    }
}
