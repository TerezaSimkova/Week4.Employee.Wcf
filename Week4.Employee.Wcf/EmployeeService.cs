using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Week4.Employee.Core;
using Week4.Employee.Core.BusinessLayer;
using Week4.Employee.Mock;

namespace Week4.Employee.Wcf
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class EmployeeService : IEmployeeService
    {
        private readonly MainBusinessLayer mainBussinessLayer;

        public EmployeeService()
        {
            mainBussinessLayer = new MainBusinessLayer(new MockEmployeeRepository());
        }

        public List<Employee1> FetchAllEmployees()
        {
            List<Employee1> employees = mainBussinessLayer.FetchEmployees();
            return employees;
        }
    }
}
