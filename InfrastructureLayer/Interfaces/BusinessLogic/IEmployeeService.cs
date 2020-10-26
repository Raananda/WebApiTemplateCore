using InfrastructureLayer.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfrastructureLayer.Interfaces.BusinessLogic
{
    public interface IEmployeeService
    {
        EmployeeDTO InsertNames(string Firstname, string LastName);
    }
}
