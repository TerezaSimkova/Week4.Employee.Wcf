using System;
using System.Collections.Generic;
using System.Text;
using Week4.Employee.Core.Interfaces;

namespace Week4.Employee.Core.BusinessLayer
{
    public class MainBusinessLayer
    {
        private readonly IEmployeeRepository employeeRepo;
        public MainBusinessLayer(IEmployeeRepository employeeRepository)
        {
            employeeRepo = employeeRepository;
        }

        public List<Employee1> FetchEmployees()
        {
            return employeeRepo.Fetch();
        }
    }
}
