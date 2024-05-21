using Events_Project_DB.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;

namespace Events_Project_DB.Pages
{
    public class OrganizerModel : PageModel
    {
        [BindProperty]
        public string Username1 { get; set; }

        private ILogger<OrganizerModel> _logger;
        private dbclass t1;
        public DataTable Table { get; set; }
        public OrganizerModel(ILogger<OrganizerModel> logger, dbclass t1)
        {
            _logger = logger;
            this.t1 = t1;
        }
        public void OnGet()
        {
            Username1 = t1.AUsername;
            Table = t1.ShowOrganizerInfo(Username1);
        }
        public IActionResult OnPostSubmit()
        {

            return RedirectToPage("/AddEvent");
        }
        public IActionResult OnPostSubmit1()
        {

            return RedirectToPage("/AddAdmin");
        }
        public IActionResult OnPostSubmit2()
        {

            return RedirectToPage("/AddOrganizer");
        }
        public IActionResult OnPostSubmit3()
        {

            return RedirectToPage("/AddSpeaker");
        }
        public IActionResult OnPostSubmit4()
        {

            return RedirectToPage("/AddPlace");
        }
    }
}
