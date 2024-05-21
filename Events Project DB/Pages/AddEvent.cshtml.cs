using Events_Project_DB.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace Events_Project_DB.Pages
{
    public class AddEventModel : PageModel
    {
        [BindProperty]
        public string Username1 { get; set; }
        [BindProperty]
        public string Username { get; set; }

        [BindProperty]
        public string eventName { get; set; }

        [BindProperty]
        public string description { get; set; }

        [BindProperty]
        public DateTime startDate { get; set; }
        [BindProperty]
        public int days { get; set; }

        [BindProperty]
        public TimeSpan time { get; set; }
        [BindProperty]
        public decimal price { get; set; }
        [BindProperty]
        public int nAttendees { get; set; }
        [BindProperty]
        public string img { get; set; }
        [BindProperty]
        public int placeID { get; set; }
        [BindProperty]
        public int speakerID { get; set; }
        [BindProperty]
        public string organizerUsername { get; set; }


        public string UserError { get; set; }

        private ILogger<AddEventModel> _logger;
        private dbclass t1;
        public DataTable Table { get; set; }
        public DataTable Table1 { get; set; }
        public DataTable Table2 { get; set; }
        public DataTable Table3 { get; set; }
        public string Guest { get; private set; }

        public AddEventModel(ILogger<AddEventModel> logger, dbclass t1)
        {
            _logger = logger;
            this.t1 = t1;
        }
        public void OnGet()
        {
            Username1 = t1.AUsername;
            Table = t1.ShowTable("Event");
            Table1 = t1.ShowTable("Speaker");
            Table2 = t1.ShowTable("Place");
            Table3 = t1.ShowTable("Organizer");

        }

        public IActionResult OnPostSubmit()
        {
            Username1 = t1.AUsername;

            Table = t1.ShowTable("Event");
            Table1 = t1.ShowTable("Speaker");
            Table2 = t1.ShowTable("Place");
            Table3 = t1.ShowTable("Organizer");
            Guest = t1.AddEvent(Table.Rows.Count + 1, eventName, description, startDate, days, time, price, nAttendees, img, placeID, speakerID, Username1);
            return RedirectToPage("/Organizer");

        }
    }
}
