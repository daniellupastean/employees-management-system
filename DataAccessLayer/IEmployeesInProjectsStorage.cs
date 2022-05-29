using LibrarieModele;
using System;
using System.Collections;
using System.Collections.Generic;

namespace NivelAccesDate
{
    public interface IEmployeesInProjectsStorage: IStocareFactory
    {
        List<EmployeeInProject> GetEmployeesInProject(int projectId);
        EmployeeInProject GetEmployeeInProject(int employeeId, int projectId);
        bool AddEmployeeInProject(EmployeeInProject einp);
        bool UpdateEmployeeInProject(EmployeeInProject einp);
    }
}
