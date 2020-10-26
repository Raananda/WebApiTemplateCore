using InfrastructureLayer.Interfaces.BusinessLogic;
using InfrastructureLayer.Interfaces.DataAccess;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer.Services
{
    public class PrintService : IPrintService
    {
        private readonly IDataAccess _dataAccess;
        private readonly ILogger<PrintService> _log;

        public PrintService(IDataAccess dataAccess, ILogger<PrintService> log)
        {
            _dataAccess = dataAccess;
            _log = log;
        }

        public void Print(string msg)
        {
            try
            {
                _dataAccess.OpenConnection();

            }

            catch(Exception ex)
            {
                _log.LogError(ex, "");
            }
      

        }
    }
}
