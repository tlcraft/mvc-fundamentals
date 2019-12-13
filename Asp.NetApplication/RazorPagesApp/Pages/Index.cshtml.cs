using Core;
using Microsoft.AspNetCore.Mvc.RazorPages;

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
