using Events_Project_DB.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace Events_Project_DB.Pages
{
    public class AddSpeakerModel : PageModel
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

        private ILogger<AddSpeakerModel> _logger;
        private dbclass t1;
        public DataTable Table { get; set; }
        public string Guest { get; private set; }

        public AddSpeakerModel(ILogger<AddSpeakerModel> logger, dbclass t1)
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

            Table = t1.ShowTable("Speaker");
            
            Guest = t1.AddSpeaker( Table.Rows.Count + 1, Name, Description, img);
            return RedirectToPage("/Admin");

        }
    }
}
