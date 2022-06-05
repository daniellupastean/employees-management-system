using LibrarieModele;
using System;
using System.Collections;
using System.Collections.Generic;

namespace NivelAccesDate
{
    public interface IEmployeesStorage: IStocareFactory
    {
        List<Employee> GetEmployees();
        Employee GetEmployee(int id);
        bool AddEmployee(Employee e);
        bool UpdateEmployee(Employee e);
        int GetEmployeesNumber();
        string GetCelebratedEmployee();
        bool DeleteEmployee(int id);
    }
}
