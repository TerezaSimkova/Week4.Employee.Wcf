using EmployeeService;
using System;
using System.Collections.Generic;
using System.Text;

namespace Week4.Employee.Client.Utilities
{
    public class Menu
    {
        //while,do while -> recuperiamo scelta utente
        //-> switch
        //1. Per visualizzare employee
        //2 ....


        //1.
        internal static void EmployeeList()
        {
            EmployeeServiceClient client = new EmployeeServiceClient();

            var employees = client.FetchAllEmployees();
            //stampo ....

        }
      

    }
}
