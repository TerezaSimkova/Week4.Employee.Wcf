using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Week4.Employee.Wcf.Selfhost
{
    class Program
    {
        static void Main(string[] args)
        {
            //servizio ce gia e lo sto ostpitando qui
            using (ServiceHost host = new ServiceHost(typeof(Week4.Employee.Wcf.EmployeeService)))
            {
                host.Open(); //si mette in ascolto sulla sua porta ,quando finisce distrugge quello che contiene
                Console.WriteLine("Premi un tasta per fermare servizio."); 
                Console.ReadKey();
            }
        }
    }
}
