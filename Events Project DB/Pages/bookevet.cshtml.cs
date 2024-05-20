using Events_Project_DB.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Data;
using System.Xml.Linq;

namespace Events_Project_DB.Pages
{
    public class bookevetModel : PageModel
    {
        private dbclass t1;
        public DataTable Table { get; set; }
        public DataTable Table1 { get; set; }
        public DataTable Table2 { get; set; }
        [BindProperty]
        public string Username1 { get; set; }
        [BindProperty]
        public int Eventid { get; set; }
        public string output { get; set; }
        public bookevetModel(ILogger<bookevetModel> logger, dbclass t1)
        {

            this.t1 = t1;
        }
        public void OnGet()
        {
            Username1 = t1.Username;
            Table = t1.ShowTable("Event");
            
        }
        public IActionResult OnPostSubmit()
        {

            Username1 = t1.Username;
            output = t1.BookEvent(Username1, Eventid);
            return RedirectToPage("/Userpage");

        }
    }
}
