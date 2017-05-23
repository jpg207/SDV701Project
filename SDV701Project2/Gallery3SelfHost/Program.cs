using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Gallery3SelfHost
{
    class Program
    {
        static void Main(string[] args)
        {
            //create a service host
            using (ServiceHost serviceHost = new ServiceHost(typeof(Service1)))
            {
                //open the servicehosts to create listeners
                //and start listening for messages
                serviceHost.Open();
                //the service can be accessed now
                Console.WriteLine("Service Is Ready");
                Console.WriteLine("Press Enter to terminate");
                Console.WriteLine();
                Console.ReadLine();
            }
        }
    }
}
