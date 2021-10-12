using System;
using System.Runtime.Serialization;

namespace Week4.Employee.Core
{
    [DataContract]
    public class Employee1
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public int Age { get; set; }
    }
}
