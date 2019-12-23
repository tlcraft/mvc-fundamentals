using DAL;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shared.Services;

namespace RazorPagesApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ICurrentDateService currentDateService;
        private readonly EfContext efContext;
        public string CurrentDate { get; set; }
        public string UserName { get; set; }

        public IndexModel(ICurrentDateService currentDateService, EfContext efContext)
        {
            this.currentDateService = currentDateService;
            this.efContext = efContext;
        }

        public void OnGet()
        {
            this.CurrentDate = currentDateService.CurrentDate;
            this.UserName = this.efContext.Users.Find(1).FirstName;
        }
    }
}
