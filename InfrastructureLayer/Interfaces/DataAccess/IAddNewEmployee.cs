using InfrastructureLayer.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfrastructureLayer.Interfaces.DataAccess
{
    public interface IAddNewEmployee
    {
        void Add(EmployeeDTO employeeDTO);
    }
}
