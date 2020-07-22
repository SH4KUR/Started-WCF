using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace GettingStartedLib
{
    public class CalculatorService : ICalculator
    {
        public double Add(double n1, double n2)
        {
            var result = n1 + n2;

            Console.WriteLine($"{ DateTime.Now.ToShortDateString() } - { DateTime.Now.ToShortTimeString() }: Add({ n1 }, { n2 })");
            Console.WriteLine($"Result = { result }");

            return result;
        }

        public double Subtract(double n1, double n2)
        {
            var result = n1 - n2;

            Console.WriteLine($"{ DateTime.Now.ToShortDateString() } - { DateTime.Now.ToShortTimeString() }: Subtract({ n1 }, { n2 })");
            Console.WriteLine($"Result = { result }");

            return result;
        }

        public double Multiply(double n1, double n2)
        {
            var result = n1 * n2;

            Console.WriteLine($"{ DateTime.Now.ToShortDateString() } - { DateTime.Now.ToShortTimeString() }: Multiply({ n1 }, { n2 })");
            Console.WriteLine($"Result = { result }");

            return result;
        }

        public double Divide(double n1, double n2)
        {
            var result = n1 / n2;

            Console.WriteLine($"{ DateTime.Now.ToShortDateString() } - { DateTime.Now.ToShortTimeString() }: Divide({ n1 }, { n2 })");
            Console.WriteLine($"Result = { result }");

            return result;
        }
    }
}
