using System.Collections.Generic;
using System.Data;
using LibrarieModele;
using Oracle.DataAccess.Client;

namespace NivelAccesDate
{
    public class EmployeesAdministrator: IEmployeesStorage
    {
        private const int PRIMUL_TABEL = 0;
        private const int PRIMA_LINIE = 0;

        public List<Employee> GetEmployees()
        {
            var result = new List<Employee>();
            var dsEmployees = SqlDBHelper.ExecuteDataSet("SELECT * FROM employees_ems_lup", CommandType.Text);

            foreach (DataRow linieBD in dsEmployees.Tables[PRIMUL_TABEL].Rows)
            {
                var employee = new Employee(linieBD);
                //incarca entitatile aditionale
                //employee.Companie = new AdministrareCompanii().GetCompanie(masina.IdCompanie);
                result.Add(employee);
            }

            return result;
        }

        public Employee GetEmployee(int id)
        {
            Employee result = null;
            var dsEmployees = SqlDBHelper.ExecuteDataSet("SELECT * FROM employees_ems_lup WHERE employee_id = :EmployeeId", CommandType.Text,
                new OracleParameter(":EmployeeId", OracleDbType.Int32, id, ParameterDirection.Input));

            if (dsEmployees.Tables[PRIMUL_TABEL].Rows.Count > 0)
            { 
                DataRow linieBD = dsEmployees.Tables[PRIMUL_TABEL].Rows[PRIMA_LINIE];
                result = new Employee(linieBD);
                //incarca entitatile aditionale
                //result.Companie = new AdministrareCompanii().GetCompanie(result.IdCompanie);
            }
            return result;
        }

        public bool AddEmployee(Employee e)
        {
            return SqlDBHelper.ExecuteNonQuery(
                "INSERT INTO employees_ems_lup VALUES (seq_employees_ems_lup.nextval, :EmployeeId, :FirstName, :LastName, :Email, :BirthDate, :HireDate, :RoleId)", CommandType.Text,
                new OracleParameter(":EmployeeId", OracleDbType.Int32, e.EmployeeId, ParameterDirection.Input),
                new OracleParameter(":FirstName", OracleDbType.NVarchar2, e.FirstName, ParameterDirection.Input),
                new OracleParameter(":LastName", OracleDbType.NVarchar2, e.LastName, ParameterDirection.Input),
                new OracleParameter(":Email", OracleDbType.NVarchar2, e.Email, ParameterDirection.Input),
                new OracleParameter(":BirthDate", OracleDbType.Date, e.BirthDate, ParameterDirection.Input),
                new OracleParameter(":HireDate", OracleDbType.Date, e.HireDate, ParameterDirection.Input),
                new OracleParameter(":RoleId", OracleDbType.Int32, e.RoleId, ParameterDirection.Input)
            );
        }

        public bool UpdateEmployee(Employee e)
        {
            return SqlDBHelper.ExecuteNonQuery(
                "UPDATE employees_ems_lup SET  first_name =:FirstName, last_name =:LastName, email =:Email, birth_date = :BirthDate, hire_date = :HireDate, role_id = :RoleId, model =:Model where employee_id=:EmployeeId", CommandType.Text,
                new OracleParameter(":FirstName", OracleDbType.NVarchar2, e.FirstName, ParameterDirection.Input),
                new OracleParameter(":LastName", OracleDbType.NVarchar2, e.LastName, ParameterDirection.Input),
                new OracleParameter(":Email", OracleDbType.NVarchar2, e.Email, ParameterDirection.Input),
                new OracleParameter(":BirthDate", OracleDbType.Date, e.BirthDate, ParameterDirection.Input),
                new OracleParameter(":HireDate", OracleDbType.Date, e.HireDate, ParameterDirection.Input),
                new OracleParameter(":RoleId", OracleDbType.Int32, e.RoleId, ParameterDirection.Input),
                new OracleParameter(":EmployeeId", OracleDbType.Int32, e.EmployeeId, ParameterDirection.Input)
            );
        }
    }
}