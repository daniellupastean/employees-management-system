using System.Collections.Generic;
using System.Data;
using LibrarieModele;
using Oracle.DataAccess.Client;

namespace NivelAccesDate
{
    public class EmployeesInProjectsAdministrator: IEmployeesInProjectsStorage
    {
        private const int PRIMUL_TABEL = 0;
        private const int PRIMA_LINIE = 0;

        public List<EmployeeInProject> GetEmployeesInProject(int projectId)
        {
            var result = new List<EmployeeInProject>();
            var dsEmployeesInProject = SqlDBHelper.ExecuteDataSet("SELECT * FROM employees_in_projects_ems_lup WHERE project_id = :ProjectId", CommandType.Text,
                 new OracleParameter(":ProjectId", OracleDbType.Int32, projectId, ParameterDirection.Input));

            foreach (DataRow linieBD in dsEmployeesInProject.Tables[PRIMUL_TABEL].Rows)
            {
                var employeeInProject = new EmployeeInProject(linieBD);
                //incarca entitatile aditionale
                employeeInProject.Employee = new EmployeesAdministrator().GetEmployee(employeeInProject.EmployeeId);
                employeeInProject.Project = new ProjectsAdministrator().GetProject(employeeInProject.ProjectId);
                employeeInProject.Role = new RolesAdministrator().GetRole(employeeInProject.RoleId);
                result.Add(employeeInProject);
            }
            return result;
        }
        public List<EmployeeInProject> GetProjectsOfEmployee(int employeeId)
        {
            var result = new List<EmployeeInProject>();
            var dsEmployeesInProject = SqlDBHelper.ExecuteDataSet("SELECT * FROM employees_in_projects_ems_lup WHERE employee_id = :EmployeeId", CommandType.Text,
                 new OracleParameter(":EmployeeId", OracleDbType.Int32, employeeId, ParameterDirection.Input));
            foreach (DataRow linieBD in dsEmployeesInProject.Tables[PRIMUL_TABEL].Rows)
            {
                var employeeInProject = new EmployeeInProject(linieBD);
                //incarca entitatile aditionale
                employeeInProject.Employee = new EmployeesAdministrator().GetEmployee(employeeInProject.EmployeeId);
                employeeInProject.Project = new ProjectsAdministrator().GetProject(employeeInProject.ProjectId);
                employeeInProject.Role = new RolesAdministrator().GetRole(employeeInProject.RoleId);
                result.Add(employeeInProject);
            }
            return result;
        }  
        public EmployeeInProject GetEmployeeInProject(int employeeId, int projectId)
        {
            EmployeeInProject employeeInProject = null;
            var dsEmployeeInProject = SqlDBHelper.ExecuteDataSet("SELECT * FROM employees_in_projects_ems_lup WHERE employee_id = :EmployeeId AND project_id = :ProjectId", CommandType.Text,
                new OracleParameter(":EmployeeId", OracleDbType.Int32, employeeId, ParameterDirection.Input),
                new OracleParameter(":ProjectId", OracleDbType.Int32, projectId, ParameterDirection.Input));

            if (dsEmployeeInProject.Tables[PRIMUL_TABEL].Rows.Count > 0)
            { 
                DataRow linieBD = dsEmployeeInProject.Tables[PRIMUL_TABEL].Rows[PRIMA_LINIE];
                employeeInProject = new EmployeeInProject(linieBD);
                //incarca entitatile aditionale
                employeeInProject.Employee = new EmployeesAdministrator().GetEmployee(employeeInProject.EmployeeId);
                employeeInProject.Project = new ProjectsAdministrator().GetProject(employeeInProject.ProjectId);
                employeeInProject.Role = new RolesAdministrator().GetRole(employeeInProject.RoleId);
            }
            return employeeInProject;
        }
        public bool AddEmployeeInProject(EmployeeInProject einp)
        {
            return SqlDBHelper.ExecuteNonQuery(
                "INSERT INTO employees_in_projects_ems_lup VALUES (seq_e_in_p_ems_lup.nextval, :EmployeeId, :ProjectId, :RoleId, :StartDate, :StopDate, :Active)", CommandType.Text,
                new OracleParameter(":EmployeeId", OracleDbType.Int32, einp.EmployeeId, ParameterDirection.Input),
                new OracleParameter(":ProjectId", OracleDbType.Int32, einp.ProjectId, ParameterDirection.Input),
                new OracleParameter(":RoleId", OracleDbType.Int32, einp.RoleId, ParameterDirection.Input),
                new OracleParameter(":StartDate", OracleDbType.Date, einp.StartDate, ParameterDirection.Input),
                new OracleParameter(":StopDate", OracleDbType.Date, einp.StopDate, ParameterDirection.Input),
                new OracleParameter(":Active", OracleDbType.Int32, einp.Active == true ? 1 : 0, ParameterDirection.Input)
            );
        }
        public bool UpdateEmployeeInProject(EmployeeInProject einp)
        {
            return SqlDBHelper.ExecuteNonQuery(
                "UPDATE employees_in_projects_ems_lup SET  employee_id =:EmployeeId, project_id =:ProjectId, role_id =:RoleId, start_date = :StartDate, stop_date = :StopDate, active =:Active where id=:Id", CommandType.Text,
                new OracleParameter(":EmployeeId", OracleDbType.Int32, einp.EmployeeId, ParameterDirection.Input),
                new OracleParameter(":ProjectId", OracleDbType.Int32, einp.EmployeeId, ParameterDirection.Input),
                new OracleParameter(":RoleId", OracleDbType.Int32, einp.EmployeeId, ParameterDirection.Input),
                new OracleParameter(":StartDate", OracleDbType.Date, einp.StartDate, ParameterDirection.Input),
                new OracleParameter(":StopDate", OracleDbType.Date, einp.StopDate, ParameterDirection.Input),
                new OracleParameter(":Active", OracleDbType.Int32, einp.Active == true ? 1 : 0, ParameterDirection.Input),
                new OracleParameter(":Id", OracleDbType.Int32, einp.Id, ParameterDirection.Input)
            );
        }
        public bool DeleteEmployeeFromProject(int id)
        {
            return SqlDBHelper.ExecuteNonQuery("DELETE FROM employees_in_projects_ems_lup WHERE id = :Id", CommandType.Text,
               new OracleParameter(":Id", OracleDbType.Int32, id, ParameterDirection.Input));
        }
    }
}