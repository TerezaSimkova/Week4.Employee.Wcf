using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Week4.Employee.Core;

namespace Week4.Employee.Wcf
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IEmployeeService
    {
        // deve avere la firma dei metodi che m ida al servizio
        [OperationContract]

        List<Employee1> FetchAllEmployees();

    }
}
