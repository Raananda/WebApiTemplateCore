using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InfrastructureLayer.DataTransferObjects;
using InfrastructureLayer.Interfaces.BusinessLogic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebApiTemplateCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly ILogger<EmployeeController> _log;
        private readonly IMainBusinessLogic _mainBusinessLogic;

        public EmployeeController(ILogger<EmployeeController> log, IMainBusinessLogic mainBusinessLogic)
        {
            _log = log;
            _mainBusinessLogic = mainBusinessLogic;
        }

        // GET: api/Employee
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet]
        public async Task<ActionResult<string>> Get()
        {
            string Response;

            //  _log.LogInformation("----- GET: api/Employee -----");
            //throw new Exception("123");
            Response = await _mainBusinessLogic.GetMessage();

            return Ok("Done");
        }


        [Route("add")]
        [HttpGet]
        public void Add()
        {
           _log.LogInformation("----- GET: api/Employee/add  {myproperty}-----",13);
            


            EmployeeDTO employeeDTO = new EmployeeDTO
            {
                FirstName = "R",
                LastName = "D"
            };

            _mainBusinessLogic.AddEmployee(employeeDTO);
        }


        // POST: api/Employee
        [HttpPost]
        public void Post(object value)
        {

        }


    }
}
