using System;
using System.Collections.Generic;

namespace SoftuniDatabaseFirstExercises.Models
{
    public partial class Employees
    {
        public Employees()
        {
            Departments = new HashSet<Department>();
            EmployeesProjects = new HashSet<EmployeesProjects>();
            InverseManager = new HashSet<Employees>();
        }

        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string JobTitle { get; set; }
        public int DepartmentId { get; set; }
        public int? ManagerId { get; set; }
        public DateTime HireDate { get; set; }
        public decimal Salary { get; set; }
        public int? AddressId { get; set; }

        public virtual Addresse Address { get; set; }
        public virtual Department Department { get; set; }
        public virtual Employees Manager { get; set; }
        public virtual ICollection<Department> Departments { get; set; }
        public virtual ICollection<EmployeesProjects> EmployeesProjects { get; set; }
        public virtual ICollection<Employees> InverseManager { get; set; }
    }
}
