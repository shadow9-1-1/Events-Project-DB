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


        public string OUsername { get; set; }
        public string Ousername1(string username)
        {
            OUsername = username;
            return OUsername;
        }


        public SqlConnection con { get; set; }
		public dbclass()
		{
            

            string SQLcon = "Data Source=ahmed;Initial Catalog=event_cave;Integrated Security=True;";

			con = new SqlConnection(SQLcon);
		}


        /*-------------------------Show Table Query----------------------*/
        public DataTable ShowTable(string Tname)
        {
            DataTable dt = new DataTable();
            string query = "select* from " + Tname;
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                dt.Load(cmd.ExecuteReader());
            }
            catch (SqlException ex)
            {

            }
            finally
            {
                con.Close();

            }

            return dt;
        }

        public DataTable ShowEventWithPlace()
        {
            DataTable dt = new DataTable();
            string query = "SELECT e.Event_ID, e.Name AS Event_Name, p.Name AS Place_Name, e.Price, e.Days, e.Start_Date, e.Description , e.img FROM Event e\r\nJOIN Event_Place ep ON e.Event_ID = ep.Event_ID\r\nJOIN Place p ON ep.Place_ID = p.ID;\r\n";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                dt.Load(cmd.ExecuteReader());
            }
            catch (SqlException ex)
            {

            }
            finally
            {
                con.Close();

            }

            return dt;
        }

        public DataTable ShowSpeaker()
        {
            DataTable dt = new DataTable();
            string query = "WITH SpeakerInfo AS (\r\n    SELECT \r\n        s.ID, \r\n        s.Name, \r\n        CAST(s.Description AS VARCHAR(MAX)) AS Description, \r\n        s.img\r\n    FROM \r\n        Speaker s\r\n)\r\nSELECT \r\n    s.ID AS Speaker_ID, \r\n    s.Name AS Speaker_Name, \r\n    s.Description AS Speaker_Description, \r\n    s.img AS Speaker_Image, \r\n    COUNT(es.EVENT_ID) AS Event_Count\r\nFROM \r\n    SpeakerInfo s\r\nLEFT JOIN \r\n    EVENT_SPEAKER es ON s.ID = es.Speaker_id\r\nGROUP BY \r\n    s.ID, s.Name, s.Description, s.img\r\nORDER BY \r\n    Event_Count DESC;\r\n";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                dt.Load(cmd.ExecuteReader());
            }
            catch (SqlException ex)
            {

            }
            finally
            {
                con.Close();

            }

            return dt;
        }

        public DataTable ShowFeedback()
        {
            DataTable dt = new DataTable();
            string query = "SELECT \r\n    f.Username,\r\n    nu.Name AS UserName,\r\n    nu.img AS UserPhoto,\r\n    e.Name AS EventName,\r\n    f.Rate,\r\n    f.Comment\r\nFROM \r\n    feedback f\r\nJOIN \r\n    Normal_User nu ON f.Username = nu.Username\r\nJOIN \r\n    Event e ON f.Event_ID = e.Event_ID;\r\n";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                dt.Load(cmd.ExecuteReader());
            }
            catch (SqlException ex)
            {

            }
            finally
            {
                con.Close();

            }

            return dt;
        }



    }
}
