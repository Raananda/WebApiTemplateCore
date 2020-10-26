using InfrastructureLayer.DataTransferObjects;
using InfrastructureLayer.Interfaces.BusinessLogic;
using InfrastructureLayer.Interfaces.DataAccess;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;

namespace DataAccessLayer
{
    public class DataAccess : IDataAccess
    {

        private string _connectionString;
        private readonly ILogger<DataAccess> _log;
        private readonly IConfiguration _config;

        public DataAccess(ILogger<DataAccess> log, IConfiguration config)
        {
            _log = log;
            _config = config;

            // Get connection string from appsetting.json file
            _connectionString = _config.GetConnectionString("Default");
        }

        public void OpenConnection()
        {
        }




        public void Add(EmployeeDTO employeeDTO)
        {

        }

        public void CloseConnection()
        {
            
        }
    }
}
