using System;
using System.Collections.Generic;
using Week4.Employee.Core;
using Week4.Employee.Core.Interfaces;

namespace Week4.Employee.Mock
{
    public class MockEmployeeRepository : IEmployeeRepository
    {

        public static List<Employee1> employees = new List<Employee1>()
        {
            new Employee1{Id = 1,FirstName= "Mario", LastName = "Rossi", Age = 30 },
            new Employee1{Id = 2,FirstName= "Alice", LastName = "Neri", Age = 28 }
        };

        public bool Add(Employee1 item)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Employee1> Fetch()
        {
            return employees;
        }

        public Employee1 GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(int id)
        {
            throw new NotImplementedException();
        }
    }
}
