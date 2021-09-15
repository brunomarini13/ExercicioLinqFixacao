using System;
using System.Globalization;
using System.Linq;
using System.IO;
using System.Collections.Generic;
using ExercicioLinqFixacao.Entities;

namespace ExercicioLinqFixacao
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter full file path: ");
            string path = Console.ReadLine();
            string[] lines = File.ReadAllLines(@path);
            List<Employee> emp = new List<Employee>();

            foreach (string s in lines)
            {
                string[] inline = s.Split(';');
                emp.Add(new Employee(inline[0], inline[1], double.Parse(inline[2])));
            }

            Console.Write("Enter salary: ");
            double salary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Console.WriteLine("Email of people whose salary is more than " + salary.ToString("f2", CultureInfo.InvariantCulture) + ":");
            var x = emp.Where(e => e.Salary > salary).OrderBy(e => e.Email).Select(e => e.Email).DefaultIfEmpty("No employee fits the criteria.").ToList();

            foreach (string s in x)
            {
                Console.WriteLine(s);
            }

            var y = emp.Where(e => e.Name[0] == 'M').Sum(e => e.Salary);
            
            Console.WriteLine("Sum of salary of people whose name starts with 'M': " + y.ToString("f2", CultureInfo.InvariantCulture));
        }
    }
}
