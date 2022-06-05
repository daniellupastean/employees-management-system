using System.Collections.Generic;
using System.Data;
using LibrarieModele;
using Oracle.DataAccess.Client;

namespace NivelAccesDate
{
    public class RolesAdministrator: IRolesStorage
    {
        private const int PRIMUL_TABEL = 0;
        private const int PRIMA_LINIE = 0;

        public List<Role> GetRoles()
        {
            var result = new List<Role>();
            var dsRoles = SqlDBHelper.ExecuteDataSet("SELECT * FROM roles_ems_lup", CommandType.Text);

            foreach (DataRow linieBD in dsRoles.Tables[PRIMUL_TABEL].Rows)
            {
                var role = new Role(linieBD);
                //incarca entitatile aditionale
                //employee.Companie = new AdministrareCompanii().GetCompanie(masina.IdCompanie);
                result.Add(role);
            }

            return result;
        }

        public Role GetRole(int id)
        {
            Role result = null;
            var dsRoles = SqlDBHelper.ExecuteDataSet("SELECT * FROM roles_ems_lup WHERE role_id = :RoleId", CommandType.Text,
                new OracleParameter(":RoleId", OracleDbType.Int32, id, ParameterDirection.Input));

            if (dsRoles.Tables[PRIMUL_TABEL].Rows.Count > 0)
            { 
                DataRow linieBD = dsRoles.Tables[PRIMUL_TABEL].Rows[PRIMA_LINIE];
                result = new Role(linieBD);
                //incarca entitatile aditionale
                //result.Companie = new AdministrareCompanii().GetCompanie(result.IdCompanie);
            }
            return result;
        }

        public bool AddRole(Role r)
        {
            return SqlDBHelper.ExecuteNonQuery(
                "INSERT INTO roles_ems_lup VALUES (seq_roles_ems_lup.nextval, :Title)", CommandType.Text,
                new OracleParameter(":Title", OracleDbType.NVarchar2, r.Title, ParameterDirection.Input)
            );
        }

        public bool UpdateRole(Role r)
        {
            return SqlDBHelper.ExecuteNonQuery(
                "UPDATE roles_ems_lup SET title=:Title WHERE role_id =:RoleId", CommandType.Text,
                new OracleParameter(":Title", OracleDbType.NVarchar2, r.Title, ParameterDirection.Input),
                new OracleParameter(":RoleId", OracleDbType.Int32, r.RoleId, ParameterDirection.Input)
            );
        }

        public bool DeleteRole(int id)
        {
            return SqlDBHelper.ExecuteNonQuery("DELETE FROM roles_ems_lup WHERE role_id = :RoleId", CommandType.Text,
                new OracleParameter(":RoleId", OracleDbType.Int32, id, ParameterDirection.Input));
        }
    }
}