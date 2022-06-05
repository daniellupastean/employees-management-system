using System;
using System.Data;

namespace LibrarieModele
{
    public class EmployeeInProject
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public virtual Employee Employee {get; set;}
        public int ProjectId { get; set; }
        public virtual Project Project { get; set; }
        public int RoleId { get; set; }
        public virtual Role Role { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime StopDate { get; set; }
        public bool Active { get; set; }

        public EmployeeInProject()
		{ }

        public EmployeeInProject(int employeeId, int projectId, int roleId, DateTime startDate, DateTime stopDate, bool active, int id = 0)
        {
            Id = id;
            EmployeeId = employeeId;
            ProjectId = projectId;
            RoleId = roleId;
            StartDate = startDate;
            StopDate = stopDate;
            Active = active;
        }

        public EmployeeInProject(DataRow linieBD)
        {
            Id = Convert.ToInt32(linieBD["id"].ToString());
            EmployeeId = Convert.ToInt32(linieBD["employee_id"].ToString());
            ProjectId = Convert.ToInt32(linieBD["project_id"].ToString());
            RoleId = Convert.ToInt32(linieBD["role_id"].ToString());
            StartDate = Convert.ToDateTime(linieBD["start_date"].ToString());
            StopDate = Convert.ToDateTime(linieBD["stop_date"].ToString());
            Active = Convert.ToInt32(linieBD["active"].ToString()) == 0 ? false : true;
        }
    }
}