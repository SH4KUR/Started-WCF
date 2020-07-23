using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;
using GettingStartedLib;

namespace GettingStartedHost
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a URI to serve as the base address.
            var baseAddress = new Uri("http://localhost:8000/GettingStarted/");

            // Create a ServiceHost instance.
            var selfHost = new ServiceHost(typeof(CalculatorService), baseAddress);

            try
            {
                // Add a service endpoint.
                selfHost.AddServiceEndpoint(typeof(ICalculator), new WSHttpBinding(), "CalculatorService");

                // Enable metadata exchange.
                var smb = new ServiceMetadataBehavior { HttpGetEnabled = true };
                selfHost.Description.Behaviors.Add(smb);

                // Start the service.
                selfHost.Open();
                Console.WriteLine("The service is ready");

                // Close the ServiceHost to stop the service.
                Console.WriteLine("Press <Enter> to terminate the service\n");
                Console.ReadLine();

                selfHost.Close();
            }
            catch (CommunicationException ce)
            {
                Console.WriteLine($"An exception occurred: { ce.Message }");
                Console.ReadLine();

                selfHost.Abort();
            }
        }
    }
}
