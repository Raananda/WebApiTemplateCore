﻿using System;
using System.Collections.Generic;
using System.Text;

namespace InfrastructureLayer.Interfaces.DataAccess
{
    public interface IDataAccess
    {
        void OpenConnection();
        void CloseConnection();
    }
}
