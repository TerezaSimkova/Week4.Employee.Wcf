using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Week4.Library.WcfSelfHost
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost host = new ServiceHost(typeof(Week4.Library.Wcf.LibraryService)))
            {
                host.Open(); //si mette in ascolto sulla sua porta ,quando finisce distrugge quello che contiene
                Console.WriteLine("Premi un tasta per fermare servizio.");
                Console.ReadKey();
            }
        }
    }
}
