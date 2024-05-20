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

        public DataTable GetUserInfo(string userName)
        {
            DataTable userInfoTable = new DataTable();

            string query = @"
    SELECT 
        nu.Username,
        nu.Name,
        nu.Password,
        nu.Email,
        nu.img
    FROM 
        Normal_User nu
    WHERE 
        nu.Username = @UserName;";

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@UserName", userName);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(userInfoTable);
            }
            catch (SqlException ex)
            {
                // Handle the exception (e.g., log it)
                // You can also return an empty DataTable or an error message depending on your error handling strategy
            }
            finally
            {
                con.Close();
            }

            return userInfoTable;
        }


        public string SignUp(string userName, string password, string name, string email)
        {
            string result = string.Empty;

            string query = "INSERT INTO Normal_User (Username, Password, Name, Email) VALUES (@UserName, @Password, @Name, @Email);";

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@UserName", userName);
                cmd.Parameters.AddWithValue("@Password", password);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Email", email);

                int rowsAffected = cmd.ExecuteNonQuery();
                result = rowsAffected.ToString();
            }
            catch (SqlException ex)
            {
                // Handle the exception (e.g., log it)
                result = "Error: " + ex.Message;
            }
            finally
            {
                con.Close();
            }

            return result;
        }

        public DataTable SearchEvents(string eventName)
        {
            DataTable eventsTable = new DataTable();

            string query = @"
    SELECT 
        e.Event_ID,
        e.Name AS Event_Name,
        p.Name AS Place_Name,
        e.Price,
        e.Days,
        e.Start_Date,
        e.Description,
        e.img AS Event_img,
        p.img AS Place_img
    FROM 
        Event e
    LEFT JOIN 
        Event_Place ep ON e.Event_ID = ep.Event_ID
    LEFT JOIN 
        Place p ON ep.Place_ID = p.ID
    WHERE 
        e.Name LIKE '%' + @EventName + '%';";

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@EventName", eventName);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(eventsTable);
            }
            catch (SqlException ex)
            {
                // Handle the exception (e.g., log it)
            }
            finally
            {
                con.Close();
            }

            return eventsTable;
        }


        public string UpdateUserData(string userName, string name, string email, string newPassword)
        {
            string result = string.Empty;

            string query = "UPDATE Normal_User SET Name = @Name, Email = @Email, Password = @Password WHERE Username = @UserName;";

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Password", newPassword);
                cmd.Parameters.AddWithValue("@UserName", userName);

                int rowsAffected = cmd.ExecuteNonQuery();
                result = rowsAffected.ToString();
            }
            catch (SqlException ex)
            {
                // Handle the exception (e.g., log it)
                result = "Error: " + ex.Message;
            }
            finally
            {
                con.Close();
            }

            return result;
        }


        public string AddFeedback(string username, int eventId, int rate, string comment)
        {
            string result = string.Empty;

            string query = "INSERT INTO feedback (Username, Event_ID, Rate, Comment) VALUES (@Username, @Event_ID, @Rate, @Comment);";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@Event_ID", eventId);
                cmd.Parameters.AddWithValue("@Rate", rate);
                cmd.Parameters.AddWithValue("@Comment", comment);
                int rowsAffected = cmd.ExecuteNonQuery();
                result = rowsAffected.ToString();
            }
            catch (SqlException ex)
            {
                
                result = "Error: " + ex.Message;
            }
            finally
            {
                con.Close();
            }
            return result;
        }

        public DataTable GetEventsForUser(string username)
        {
            DataTable dt = new DataTable();
            string query = @"SELECT Event.Event_ID, Event.Name, Event.Description, Event.Start_Date, Event.Days, Event.Time, Event.Price, Event.N_Attendees, Event.N_Booked, Event.img
                    FROM User_Tickets
                    INNER JOIN Event ON User_Tickets.Event_ID = Event.Event_ID
                    WHERE User_Tickets.Username = @Username;";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Username", username);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
            }
            catch (SqlException ex)
            {
                // Handle the exception, log it, etc.
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
            return dt;
        }
        public string BookEvent(string username, int eventId)
        {
            string result = string.Empty;

            string queryInsert = "INSERT INTO User_Tickets (Username, Event_ID) VALUES (@Username, @Event_ID);";
            string queryUpdate = "UPDATE Event SET N_Booked = N_Booked + 1 WHERE Event_ID = @Event_ID;";

            try
            {
                con.Open();
                SqlTransaction transaction = con.BeginTransaction();
                SqlCommand cmdInsert = new SqlCommand(queryInsert, con, transaction);
                cmdInsert.Parameters.AddWithValue("@Username", username);
                cmdInsert.Parameters.AddWithValue("@Event_ID", eventId);
                SqlCommand cmdUpdate = new SqlCommand(queryUpdate, con, transaction);
                cmdUpdate.Parameters.AddWithValue("@Event_ID", eventId);

                cmdInsert.ExecuteNonQuery();
                cmdUpdate.ExecuteNonQuery();

                transaction.Commit();
                result = "Booking successful!";
            }
            catch (SqlException ex)
            {
                // Handle the exception, log it, etc.
                result = "Error: " + ex.Message;
            }
            finally
            {
                con.Close();
            }

            return result;
        }


        public DataTable BookingHistory(string username)
        {
            DataTable bookingHistory = new DataTable();

            string query = "SELECT e.Event_ID, e.Name AS Event_Name, e.Start_Date, e.Time, e.Price " +
                           "FROM User_Tickets ut " +
                           "JOIN Event e ON ut.Event_ID = e.Event_ID " +
                           "WHERE ut.Username = @Username;";

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Username", username);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(bookingHistory);
            }
            catch (SqlException ex)
            {
                // Handle the exception, log it, etc.
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                con.Close();
            }

            return bookingHistory;
        }

    }
}
