using Events_Project_DB.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;

namespace Events_Project_DB.Pages
{
    public class AllTableModel : PageModel
    {
        private readonly ILogger<AllTableModel> _logger;


        private dbclass t1;
        public DataTable Table { get; set; }
        public DataTable Table1 { get; set; }
        public DataTable Table2 { get; set; }
        public DataTable Table3 { get; set; }
        public DataTable Table4 { get; set; }
        public DataTable Table5 { get; set; }
        public DataTable Table6 { get; set; }
        public DataTable Table7 { get; set; }
        public DataTable Table8 { get; set; }
        public DataTable Table9 { get; set; }





        [BindProperty]
        public int EventID { get; set; }
        [BindProperty]
        public string Username1 { get; set; }
        public AllTableModel(ILogger<AllTableModel> logger, dbclass t1)
        {
            _logger = logger;
            this.t1 = t1;
        }
        public void OnGet()
        {
            Username1 = t1.AUsername;
            Table8 = t1.ShowAdminInfo(Username1);
            Table = t1.ShowTable("Event");
            Table1 = t1.ShowTable("Speaker");
            Table2 = t1.ShowTable("Place");
            Table3 = t1.ShowTable("Organizer");
            Table4 = t1.ShowTable("Normal_User");
            Table5 = t1.ShowFeedback();
            Table6 = t1.ShowTable("Admin");
            Table7 = t1.GetAllEvents();

        }
    }
}
