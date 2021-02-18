using System;
using System.Collections.Generic;
using System.Text;

namespace P06_CompanyRoster
{
    public class Company
    {
        private List<Employee> employes = new List<Employee>();

        public void AddEmployee(Employee employee)
        {
            employes.Add(employee);
        }

        public List<Employee> GetEmployes()
        {
            return employes;
        }
    }
}
