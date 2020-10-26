using InfrastructureLayer.DataTransferObjects;
using InfrastructureLayer.Interfaces.BusinessLogic;
using InfrastructureLayer.Interfaces.DataAccess;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class MainBusinessLogic : IMainBusinessLogic
    {
        private readonly ILogger<MainBusinessLogic> _log;
        private readonly IConfiguration _config;
        private readonly IDataAccess _dataAccess;
        private readonly IEmployeeService _employeeService;

        private EmployeeDTO _employeeDTO;

        public MainBusinessLogic(
            ILogger<MainBusinessLogic> log,
            IConfiguration config,
            IDataAccess dataAccess,
            IEmployeeService employeeService
            )
        {
            _log = log;
            _config = config;
            _dataAccess = dataAccess;
            _employeeService = employeeService;

            //// Get value from appsettings.json
            //var Value1 = _config.GetValue<int>("SomeKey");
            //var Value2 = _config.GetValue<int>("SomeSection:Somekey");

        }

        public void AddEmployee(EmployeeDTO employee)
        {

            //_log.LogInformation("ADDED");


            // _employeeDTO = _employeeService.InsertNames(employee.FirstName, employee.LastName);
        }

        public async Task<string> GetMessage()
        {
            await Task.Delay(1);
   
            return "Hello from server";
        }

        public void Run()
        {
         //   _dataAccess.OpenConnection();

            //Run Employee service
            _employeeDTO = _employeeService.InsertNames("Raanan", "Dalal");

        }
    }
}
