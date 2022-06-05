using LibrarieModele;
using System;
using System.Collections;
using System.Collections.Generic;

namespace NivelAccesDate
{
    public interface IEmployeesInProjectsStorage: IStocareFactory
    {
        List<EmployeeInProject> GetEmployeesInProject(int projectId);
        List<EmployeeInProject> GetProjectsOfEmployee(int employeeId);
        EmployeeInProject GetEmployeeInProject(int employeeId, int projectId);
        bool AddEmployeeInProject(EmployeeInProject einp);
        bool UpdateEmployeeInProject(EmployeeInProject einp);
        bool DeleteEmployeeFromProject(int id);
    }
}
