using Events_Project_DB.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;

namespace Events_Project_DB.Pages
{
    public class bookhistoryModel : PageModel
    {
        public string Username1 { get; set; }

        private readonly ILogger<bookhistoryModel> _logger;
        private readonly dbclass _t1;
        public bookhistoryModel(ILogger<bookhistoryModel> logger, dbclass t1)
        {
            _logger = logger;
            _t1 = t1;
        }
        public DataTable Table { get; set; }
        public void OnGet()
        {
            Username1 = _t1.Username;
            Table = _t1.BookingHistory(Username1);
        }
    }
}
