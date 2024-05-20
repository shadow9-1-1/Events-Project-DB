using Events_Project_DB.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace Events_Project_DB.Pages
{
    public class loginAOModel : PageModel
    {
        [BindProperty]
        [Required(ErrorMessage = "Username is required.")]
        public string Username { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string UserError { get; set; }
        [BindProperty]
        public string Select { get; set; }

        private readonly ILogger<loginAOModel> _logger;
        private readonly dbclass _t1;

        public DataTable Table { get; set; }
        public DataTable Table1 { get; set; }
        public DataTable Table2 { get; set; }

        public loginAOModel(ILogger<loginAOModel> logger, dbclass t1)
        {
            _logger = logger;
            _t1 = t1;
        }
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (Select == "Admin")
            {
                if (ModelState.IsValid)
                {
                    Table = _t1.ShowTable("Admin");
                    for (int i = 0; i < Table.Rows.Count; i++)
                    {
                        if (Username == Table.Rows[i]["user_name"].ToString() && Password == Table.Rows[i]["Password"].ToString())
                        {
                            _t1.Ausername1(Username);
                            return RedirectToPage("/Admin");


                        }
                    }
                }
                UserError = "Username or password are incorrect";
                return Page();
            }
            else if (Select == "Organizer")
            {
                if (ModelState.IsValid)
                {
                    Table = _t1.ShowTable("Organizer");
                    for (int i = 0; i < Table.Rows.Count; i++)
                    {
                        if (Username == Table.Rows[i]["UserName"].ToString() && Password == Table.Rows[i]["Password"].ToString())
                        {
                            _t1.Ausername1(Username);
                            return RedirectToPage("/Organizer");


                        }
                    }
                }
                UserError = "Username or password are incorrect";
                return Page();
            }
            


            UserError = "Select Your Role First";
            return Page();


        }
    }
}
