using System;
using System.Collections;
using System.Collections.Generic;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();
            p.Start();
            Console.ReadKey();
        }

        public void Start()
        {
            Calculator calc = new Calculator();
            string[] stringValues = Console.ReadLine().Split(' ');
            double a = double.Parse(stringValues[0]);
            double b = double.Parse(stringValues[2]);
            var rez = calc.PerformOperations(stringValues[1], a, b);
            Console.Write($" {rez}");
        }
    }

    class Calculator
    {
        private Dictionary<string, Func<double, double, double>> _operations;
        public Calculator()
        {
            _operations = new Dictionary<string, Func<double, double, double>>
            {
                { "+", (x, y) => x + y},
                { "-", (x, y) => x - y},
                { "*", (x, y) => x * y},
                { "/", (x, y) => x / y},
            };
        }

        public double PerformOperations(string op, double x, double y) //выполнить операцию
        {
            if (!_operations.ContainsKey(op))
            {
                throw new ArgumentException($"The opration {op} doesn't exist!");
            }

            return _operations[op](x, y);
        }

        public void DefineOperation(string op, Func<double, double, double> body)
        {
            if (_operations.ContainsKey(op))
            {
                throw new ArgumentException($"The operation {op} is already exist!");
            }

            _operations.Add(op, body);
        } 
    }
}
