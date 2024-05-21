using Events_Project_DB.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace Events_Project_DB.Pages
{
    public class AddOrganizerModel : PageModel
    {
        [BindProperty]
        public string Username1 { get; set; }
        [BindProperty]
        [Required(ErrorMessage = "Username is required.")]
        public string Username { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Description is required.")]
        public string Description { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "img is required.")]
        public string img { get; set; }

        public string UserError { get; set; }

        private ILogger<AddOrganizerModel> _logger;
        private dbclass t1;
        public DataTable Table { get; set; }
        public string Guest { get; private set; }

        public AddOrganizerModel(ILogger<AddOrganizerModel> logger, dbclass t1)
        {
            _logger = logger;
            this.t1 = t1;
        }
        public void OnGet()
        {
            Username1 = t1.AUsername;



        }

        public IActionResult OnPost()
        {

            Table = t1.ShowTable("Organizer");
            for (int i = 0; i < Table.Rows.Count; i++)
            {
                if (Username.Equals(Table.Rows[i][0].ToString(), StringComparison.OrdinalIgnoreCase))
                {
                    UserError = "Username unavailable";
                    return Page();
                }
            }

            Guest = t1.AddOrganizer(Username, Name, Password, Description,img);
            return RedirectToPage("/Admin");


        }
    }
}
