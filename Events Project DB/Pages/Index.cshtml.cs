using Events_Project_DB.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;

namespace Events_Project_DB.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;


        private dbclass t1;
        public DataTable Table { get; set; }
        public DataTable Table1 { get; set; }
        public DataTable Table2 { get; set; }


        [BindProperty]
        public int EventID { get; set; }
        [BindProperty]
        public string eventSearch { get; set; }
        public IndexModel(ILogger<IndexModel> logger, dbclass t1)
        {
            _logger = logger;
            this.t1 = t1;
        }

        public void OnGet()
        {
            Table = t1.ShowEventWithPlace();
            Table1 = t1.ShowSpeaker();
            Table2 = t1.ShowFeedback();
        }
        public IActionResult OnPostSearch()
        {
            return RedirectToPage("/eventSearch", new { eventSearchName = eventSearch });
        }
    }
}