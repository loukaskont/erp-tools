﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ektiposeis.MyClass
{
    public class SqlServerDatabase
    {
        String connectionString = "";
        public void connect(String _connectionString)
        {
            connectionString = _connectionString;
        }
    }
}