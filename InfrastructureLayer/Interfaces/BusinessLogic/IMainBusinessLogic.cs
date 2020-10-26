using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureLayer.Interfaces.BusinessLogic
{
   public interface IMainBusinessLogic: IAddNewEmployee
    {
        void Run();

        Task<string> GetMessage();
    }
}
