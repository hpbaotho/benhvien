﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hospital.Model;
using System.Data;

namespace Hospital.Controller
{
    class DepartmentController
    {
        public DataTable GetListFunction()
        {
            DataTable dtF = new DataTable();

            return dtF;
        }
        public DataTable GetFunction()
        {
            DataTable newFunction = new DataTable();

            return newFunction;
        }
        public Boolean InsertFunction(Function newFunction)
        {
            return true;
        }
        public Boolean UpdateFunction(Function newFunction)
        {
            return true;
        }
        public Boolean DeleteFunction(Function newFunction)
        {
            return true;
        }
    }
    
}
