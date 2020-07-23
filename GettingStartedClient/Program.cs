using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using GettingStartedClient.ServiceReference1;

namespace GettingStartedClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var numberOperation = SetOperation();
            var arguments = SetArguments();

            Calculation(numberOperation, arguments[0], arguments[1]);

            Console.WriteLine("Press <Enter> to terminate the client");
            Console.ReadLine();
        }

        private static int SetOperation()
        {
            var selectedOperation = 0;
         
            Console.WriteLine("Select Operation:\n");
            Console.WriteLine("1.Add (+)");
            Console.WriteLine("2.Subtract (-)");
            Console.WriteLine("3.Multiply (*)");
            Console.WriteLine("4.Divide (/)");

            Console.Write("Enter: ");
            while (!int.TryParse(Console.ReadLine(), out selectedOperation) && (selectedOperation < 1 || selectedOperation > 4))
            {
                Console.Write("Incorrect Input! Enter: ");
            }

            return selectedOperation;
        }

        private static double[] SetArguments()
        {
            var arg = new double[2];

            Console.WriteLine("Set Arguments (X1 and X2):\n");
            for (var i = 0; i < 2; i++)
            {
                Console.Write($"Set X{ i + 1 }: ");
                while (!double.TryParse(Console.ReadLine(), out arg[i]))
                {
                    Console.Write($"Incorrect Input! Set X{ i + 1 }: ");
                }
            }

            return arg;
        }

        private static void Calculation(int operation, double arg1, double arg2)
        {
            var calculatorClient = new CalculatorClient();

            switch (operation)
            {
                case 1:
                    var result = calculatorClient.Add(arg1, arg2);
                    Console.WriteLine($"\nAdd: { arg1 } + { arg2 } = { result }");
                    break;
                case 2:
                    result = calculatorClient.Subtract(arg1, arg2);
                    Console.WriteLine($"\nSubtract: { arg1 } - { arg2 } = { result }");
                    break;
                case 3:
                    result = calculatorClient.Multiply(arg1, arg2);
                    Console.WriteLine($"\nMultiply: { arg1 } * { arg2 } = { result }");
                    break;
                case 4:
                    result = calculatorClient.Divide(arg1, arg2);
                    Console.WriteLine($"\nDivide: { arg1 } / { arg2 } = { result }");
                    break;
            }

            calculatorClient.Close();
        }
    }
}
