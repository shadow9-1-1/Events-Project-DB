using Events_Project_DB.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace Events_Project_DB.Pages
{
    public class AddPlaceModel : PageModel
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
        [Required(ErrorMessage = "Country is required.")]
        public string Country { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "City is required.")]
        public string City { get; set; }
        [BindProperty]
        [Required(ErrorMessage = "Address is required.")]
        public string Address { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "img is required.")]
        public string img { get; set; }

        public string UserError { get; set; }

        private ILogger<AddPlaceModel> _logger;
        private dbclass t1;
        public DataTable Table { get; set; }
        public string Guest { get; private set; }

        public AddPlaceModel(ILogger<AddPlaceModel> logger, dbclass t1)
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

            Table = t1.ShowTable("Place");
            
            Guest = t1.AddPlace(Table.Rows.Count + 1, Name, Country, City, Address, img);
            return RedirectToPage("/Admin");

        }
    }
}
