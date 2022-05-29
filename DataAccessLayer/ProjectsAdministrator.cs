using System.Collections.Generic;
using System.Data;
using LibrarieModele;
using Oracle.DataAccess.Client;

namespace NivelAccesDate
{
    public class ProjectsAdministrator: IProjectsStorage
    {
        private const int PRIMUL_TABEL = 0;
        private const int PRIMA_LINIE = 0;

        public List<Project> GetProjects()
        {
            var result = new List<Project>();
            var dsProjects = SqlDBHelper.ExecuteDataSet("SELECT * FROM projects_ems_lup", CommandType.Text);

            foreach (DataRow linieBD in dsProjects.Tables[PRIMUL_TABEL].Rows)
            {
                var project = new Project(linieBD);
                //incarca entitatile aditionale
                //employee.Companie = new AdministrareCompanii().GetCompanie(masina.IdCompanie);
                result.Add(project);
            }

            return result;
        }

        public Project GetProject(int id)
        {
            Project result = null;
            var dsProjects = SqlDBHelper.ExecuteDataSet("SELECT * FROM projects_ems_lup WHERE project_id = :ProjectId", CommandType.Text,
                new OracleParameter(":ProjectId", OracleDbType.Int32, id, ParameterDirection.Input));

            if (dsProjects.Tables[PRIMUL_TABEL].Rows.Count > 0)
            { 
                DataRow linieBD = dsProjects.Tables[PRIMUL_TABEL].Rows[PRIMA_LINIE];
                result = new Project(linieBD);
                //incarca entitatile aditionale
                //result.Companie = new AdministrareCompanii().GetCompanie(result.IdCompanie);
            }
            return result;
        }

        public bool AddProject(Project p)
        {
            return SqlDBHelper.ExecuteNonQuery(
                "INSERT INTO projects_ems_lup VALUES (seq_projects_ems_lup.nextval, :ProjectId, :Title, :Finished)", CommandType.Text,
                new OracleParameter(":ProjectId", OracleDbType.Int32, p.ProjectId, ParameterDirection.Input),
                new OracleParameter(":Title", OracleDbType.NVarchar2, p.Title, ParameterDirection.Input),
                new OracleParameter(":Finished", OracleDbType.Int32, p.Finished, ParameterDirection.Input)
            );
        }

        public bool UpdateProject(Project p)
        {
            return SqlDBHelper.ExecuteNonQuery(
                "UPDATE projects_ems_lup SET title=:Title, finished =:Finished WHERE project_id=:ProjectId", CommandType.Text,
                new OracleParameter(":Title", OracleDbType.NVarchar2, p.Title, ParameterDirection.Input),
                new OracleParameter(":Finished", OracleDbType.Int32, p.Finished, ParameterDirection.Input),
                new OracleParameter(":ProjectId", OracleDbType.Int32, p.ProjectId, ParameterDirection.Input)
            );
        }
    }
}