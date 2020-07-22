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
            var baseAddress = new Uri("http://localhost:8000/GettingStarted/");
            var selfHost = new ServiceHost(typeof(CalculatorService), baseAddress);

            try
            {
                selfHost.AddServiceEndpoint(typeof(ICalculator), new WSHttpBinding(), "CalculatorService");

                var smb = new ServiceMetadataBehavior { HttpGetEnabled = true };
                selfHost.Description.Behaviors.Add(smb);

                selfHost.Open();
                Console.WriteLine("The service is ready");

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
