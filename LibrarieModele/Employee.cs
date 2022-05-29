using System;
using System.Data;

namespace LibrarieModele
{
	public class Employee
	{
       
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime HireDate { get; set; }
        public int RoleId { get; set; }

        public Employee()
        { }

        public Employee(string firstName, string lastName, string email, DateTime birthDate, DateTime hireDate, int roleId, int employeeId = 0)
        {
            EmployeeId = employeeId;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            BirthDate = birthDate;
            HireDate = hireDate;
            RoleId = roleId;
        }

        public Employee(DataRow linieBD)
        {
            EmployeeId = Convert.ToInt32(linieBD["employee_id"].ToString());
            FirstName = linieBD["first_name"].ToString();
            LastName = linieBD["last_name"].ToString();
            Email = linieBD["email"].ToString();
            BirthDate = Convert.ToDateTime(linieBD["birth_date"].ToString());
            HireDate = Convert.ToDateTime(linieBD["hire_date"].ToString());
            RoleId = Convert.ToInt32(linieBD["role_id"].ToString());
        }
    }
}
