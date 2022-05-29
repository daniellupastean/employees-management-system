using System;
using System.Data;

namespace LibrarieModele
{
	public class Project
	{
        public int ProjectId { get; set; }
        public string Title { get; set; }
        public bool Finished { get; set; }

        public Project()
		{ }

        public Project(string title, bool finished, int projectId = 0)
        {
            ProjectId = projectId;
            Title = title;
            Finished = finished;
        }

        public Project(DataRow linieBD)
        {
            ProjectId = Convert.ToInt32(linieBD["project_id"].ToString());
            Title = linieBD["title"].ToString();
            Finished = Convert.ToInt32(linieBD["finished"].ToString()) == 0 ? false : true;
        }
    }
}