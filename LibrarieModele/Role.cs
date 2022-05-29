using System;
using System.Data;

namespace LibrarieModele
{
	public class Role
	{
		public int RoleId { get; set; }
		public string Title { get; set; }

		public Role()
		{ }

		public Role(string title, int roleId = 0)
        {
			RoleId = roleId;
			Title = title;
        }

		public Role(DataRow linieBD)
        {
			RoleId = Convert.ToInt32(linieBD["role_id"].ToString());
			Title = linieBD["title"].ToString();
		}
	}
}
