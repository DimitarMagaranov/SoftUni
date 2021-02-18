using System;
using System.Collections.Generic;
using System.Linq;

namespace P06_CompanyRoster
{
    public class Program
    {
        public static void Main()
        {
            int numberOfEmployeToAdd = int.Parse(Console.ReadLine());

            Company company = new Company();

            Employee employee;

            for (int i = 0; i < numberOfEmployeToAdd; i++)
            {
                string[] employeTokens = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string name = employeTokens[0];
                double salary = double.Parse(employeTokens[1]);
                string position = employeTokens[2];
                string department = employeTokens[3];
                string email = string.Empty;
                int age = 0;

                if (employeTokens.Length == 4)
                {
                    employee = new Employee(name, salary, position, department);
                    company.AddEmployee(employee);
                }
                else if (employeTokens.Length == 5)
                {
                    bool tryingParse = int.TryParse(employeTokens[4], out _);

                    if (tryingParse)
                    {
                        age = int.Parse(employeTokens[4]);

                        employee = new Employee(name, salary, position, department, age);

                        company.AddEmployee(employee);
                    }
                    else
                    {
                        email = employeTokens[4];

                        employee = new Employee(name, salary, position, department, email);

                        company.AddEmployee(employee);
                    }
                }
                else if (employeTokens.Length == 6)
                {
                    email = employeTokens[4];
                    age = int.Parse(employeTokens[5]);

                    employee = new Employee(name, salary, position, department, email, age);

                    company.AddEmployee(employee);
                }
            }

            Dictionary<string, List<Employee>> departments = new Dictionary<string, List<Employee>>();

            List<Employee> employes = company.GetEmployes();

            foreach (var employe in employes)
            {
                if (departments.ContainsKey(employe.Department) == false)
                {
                    departments.Add(employe.Department, new List<Employee>());
                }

                departments[employe.Department].Add(employe);
            }

            string departmentWithHighAverageSalary = string.Empty;
            double highAverageSalary = 0;

            foreach (var department in departments)
            {
                int countOfEmployes = department.Value.Count;
                double currSum = 0;
                
                foreach (var employe in department.Value)
                {
                    currSum += employe.Salary;
                }

                double currAverage = currSum / countOfEmployes;

                if (currAverage > highAverageSalary)
                {
                    highAverageSalary = currAverage;
                    departmentWithHighAverageSalary = department.Key;
                }
            }

            Console.WriteLine($"Highest Average Salary: {departmentWithHighAverageSalary}");

            foreach (var department in departments.Where(x => x.Key == departmentWithHighAverageSalary))
            {
                foreach (var employe in department.Value.OrderByDescending(x => x.Salary))
                {
                    Console.WriteLine($"{employe.Name} {employe.Salary:f2} {employe.Email} {employe.Age}");
                }
            }
        }
    }
}
