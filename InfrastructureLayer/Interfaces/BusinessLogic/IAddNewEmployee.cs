using InfrastructureLayer.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfrastructureLayer.Interfaces.BusinessLogic
{
    public interface IAddNewEmployee
    {
        void AddEmployee(EmployeeDTO employeeDTO);
    }
}
