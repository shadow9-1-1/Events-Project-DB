using Events_Project_DB.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;

namespace Events_Project_DB.Pages
{
    public class UserPageModel : PageModel
    {
        

        [BindProperty(SupportsGet = true)]
        public string Username { get; set; }
        [BindProperty]
        public string Username1 { get; set; }

        private ILogger<UserPageModel> _logger;
        private dbclass t1;
        public DataTable Table { get; set; }


        public UserPageModel(ILogger<UserPageModel> logger, dbclass t1)
        {
            _logger = logger;
            this.t1 = t1;
        }
        public void OnGet()
        {
            Username1 = t1.Username;
            Table = t1.GetUserInfo(Username1);
            

        }
        public IActionResult OnPostSubmit()
        {

            return RedirectToPage("/Updatedata");
        }
        public IActionResult OnPostSubmit1()
        {

            return RedirectToPage("/bookevet");
        }
        public IActionResult OnPostSubmit2()
        {

            return RedirectToPage("/bookhistory");
        }
        public IActionResult OnPostSubmit3()
        {

            return RedirectToPage("/Feedback");
        }
    }
}
