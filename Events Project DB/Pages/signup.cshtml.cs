using Events_Project_DB.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace Events_Project_DB.Pages
{
    public class signupModel : PageModel
    {
        [BindProperty]
        [Required(ErrorMessage = "Username is required.")]
        public string Username { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string Email { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string UserError { get; set; }
        public string Guest { get; set; }

        private readonly ILogger<signupModel> _logger;
        private readonly dbclass _t1;

        public DataTable Table { get; set; }
        public DataTable Table1 { get; set; }
        public DataTable Table2 { get; set; }

        public signupModel(ILogger<signupModel> logger, dbclass t1)
        {
            _logger = logger;
            _t1 = t1;
        }
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                Table = _t1.ShowTable("Normal_User");
                for (int i = 0; i < Table.Rows.Count; i++)
                {
                    if (Username.Equals(Table.Rows[i][0].ToString(), StringComparison.OrdinalIgnoreCase))
                    {
                        UserError = "Username unavailable";
                        return Page();
                    }
                }

                Guest = _t1.SignUp(Username, Password, Name, Email);
                return RedirectToPage("/login");
            }

            return Page();
        }
    }
}
