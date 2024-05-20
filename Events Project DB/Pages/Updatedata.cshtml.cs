using Events_Project_DB.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;

namespace Events_Project_DB.Pages
{
    public class UpdatedataModel : PageModel
    {
        private readonly ILogger<UpdatedataModel> _logger;
        private readonly dbclass _t1;
        public UpdatedataModel(ILogger<UpdatedataModel> logger, dbclass t1)
        {
            _logger = logger;
            _t1 = t1;
        }
        public DataTable Table { get; set; }

        [BindProperty]
        public string name { get; set; }
        [BindProperty]
        public string email { get; set; }
        [BindProperty]
        public string password { get; set; }
        [BindProperty]
        public string message { get; set; }

        public void OnGet()
        {
            Table = _t1.GetUserInfo(_t1.Username);
        }
        public IActionResult OnPostSubmit()
        {
            message = _t1.UpdateUserData(_t1.Username, name, email, password);
            return RedirectToPage("/UserPage");
        }
        public IActionResult OnPostCancel()
        {
            return RedirectToPage("/UserPage");

        }
        
    }
}
