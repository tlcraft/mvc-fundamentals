extern alias SharedComponents;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SharedComponents::Shared.Services;

namespace RazorPagesApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ICurrentDateService currentDateService;
        private readonly IUserService userService;
        public string CurrentDate { get; set; }
        public string UserName { get; set; }

        public IndexModel(ICurrentDateServiceFactory currentDateServiceFactory, IUserService userService)
        {
            this.currentDateService = currentDateServiceFactory.GetCurrentDateService();
            this.userService = userService;
        }

        public void OnGet()
        {
            this.CurrentDate = currentDateService.CurrentDate;
            this.UserName = this.userService.GetUser(1).FirstName;
        }
    }
}
