using Events_Project_DB.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;

namespace Events_Project_DB.Pages
{
    public class eventSearchModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string eventSearchName { get; set; }
        public DataTable Table { get; set; }
        [BindProperty]
        public int EventID { get; set; }

        private readonly ILogger<eventSearchModel> _logger;
        private readonly dbclass t1;
        public eventSearchModel(ILogger<eventSearchModel> logger, dbclass t1)
        {
            _logger = logger;
            this.t1 = t1;
        }
        public void OnGet()
        {
            Table = t1.SearchEvents(eventSearchName);

        }
    }
}
