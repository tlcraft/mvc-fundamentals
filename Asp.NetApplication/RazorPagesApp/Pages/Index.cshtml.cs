using Microsoft.AspNetCore.Mvc.RazorPages;
using Shared.Services;

namespace RazorPagesApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ICurrentDateService currentDateService;
        private readonly IUserService userService;
        public string CurrentDate { get; set; }
        public string UserName { get; set; }

        public IndexModel(ICurrentDateService currentDateService, IUserService userService)
        {
            this.currentDateService = currentDateService;
            this.userService = userService;
        }

        public void OnGet()
        {
            this.CurrentDate = currentDateService.CurrentDate;
            this.UserName = this.userService.GetUser(1).FirstName;
        }
    }
}
