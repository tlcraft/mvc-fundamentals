using Microsoft.AspNetCore.Mvc.RazorPages;
using Shared;

namespace RazorPagesApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ICurrentDateService currentDateService;
        public string CurrentDate { get; set; }

        public IndexModel(ICurrentDateService currentDateService)
        {
            this.currentDateService = currentDateService;
        }

        public void OnGet()
        {
            this.CurrentDate = currentDateService.CurrentDate;
        }
    }
}
