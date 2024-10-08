using Events_Project_DB.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;

namespace Events_Project_DB.Pages
{
    public class AdminModel : PageModel
    {
        [BindProperty]
        public string Username1 { get; set; }

        private ILogger<AdminModel> _logger;
        private dbclass t1;
        public DataTable Table { get; set; }
        public AdminModel(ILogger<AdminModel> logger, dbclass t1)
        {
            _logger = logger;
            this.t1 = t1;
        }
        public void OnGet()
        {
            Username1 = t1.AUsername;
            Table = t1.ShowAdminInfo(Username1);


        }
        public IActionResult OnPostSubmit()
        {

            return RedirectToPage("/AllTable");
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
