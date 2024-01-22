using AspProjectZust.Entities.Entity;
using AspProjectZust.WebUI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.EntityFrameworkCore;

namespace AspProjectZust.WebUI.ViewComponents
{
    public class UserInfoViewComponent : ViewComponent
    {
        private UserManager<CustomIdentityUser> _userManager;
        private CustomIdentityDbContext _dbContext;

        public UserInfoViewComponent(UserManager<CustomIdentityUser> userManager, CustomIdentityDbContext context)
        {
            _userManager = userManager;
            _dbContext = context;
        }

        public ViewViewComponentResult Invoke()
        {
            var user = _userManager.GetUserAsync(HttpContext.User).Result;
            var requests = _dbContext.FriendRequests.Where(r => r.ReceiverId == user.Id).ToList();

            var user2 = new UserInfoViewModel
            {
                UserName = user.UserName,
                Email = user.Email,
                ImageUrl = user.ImageUrl,
            };

            if (requests != null)
            {
                user2.userRequestCount = requests.Count();
            }
            else
            {
                user2.userRequestCount = 0;
            }

            return View(user2);
        }
    }
}
