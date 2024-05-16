using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Data;
using System.Data.SqlClient;


namespace Events_Project_DB.Model
{
	public class dbclass
	{
		[BindProperty]
		public string AUsername { get; set; }
		public string Ausername1(string Ausername)
		{
			AUsername = Ausername;
			return AUsername;
		}
		[BindProperty]
		public string Username { get; set; }
		public string username1(string username)
		{
			Username = username;
			return Username;
		}

		/*
		public SqlConnection con { get; set; }
		public dbclass()
		{
			string SQLcon = "Data Source=Ahmed;Initial Catalog=Hotel;Integrated Security=True;";

			con = new SqlConnection(SQLcon);
		}
		*/
	}
}
