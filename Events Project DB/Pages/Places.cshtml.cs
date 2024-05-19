using Events_Project_DB.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;

namespace Events_Project_DB.Pages
{
    public class PlacesModel : PageModel
    {
        private dbclass t1;
        public DataTable Table { get; set; }
        public DataTable Table1 { get; set; }
        public DataTable Table2 { get; set; }

        public PlacesModel(ILogger<PlacesModel> logger, dbclass t1)
        {

            this.t1 = t1;
        }

        public void OnGet()
        {
            Table = t1.ShowTable("Place");
            /*Table1 = t1.ShowTable("Services");
            Table2 = t1.ShowTable("RoomType");*/
        }
    }
}
