using AspProjectZust.Entities.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace AspProjectZust.WebUI.Hubs
{
    public class UserHub : Hub
    {
        private UserManager<CustomIdentityUser> _userManager;
        private IHttpContextAccessor _contextAccessor;
        private CustomIdentityDbContext _context;

        public UserHub(UserManager<CustomIdentityUser> userManager, IHttpContextAccessor contextAccessor, CustomIdentityDbContext context)
        {
            _userManager = userManager;
            _contextAccessor = contextAccessor;
            _context = context;
        }



        public async override Task OnConnectedAsync()
        {
            var user = await _userManager.GetUserAsync(_contextAccessor.HttpContext.User);
            var userItem = _context.Users.SingleOrDefault(x => x.Id == user.Id);
            userItem.IsOnline = true;
            //_context.Update(userItem);

            await _context.SaveChangesAsync();

            string info = user.UserName + " connected successfully";
            await Clients.Others.SendAsync("Connect", info);
        }

        public async override Task OnDisconnectedAsync(Exception? exception)
        {
            var user = await _userManager.GetUserAsync(_contextAccessor.HttpContext.User);
            var userItem = _context.Users.SingleOrDefault(x => x.Id == user.Id);
            userItem.IsOnline = false;
            //userItem.DisconnectTime = DateTime.Now;
            _context.Update(userItem);
            await _context.SaveChangesAsync();
            //string info = user.UserName + " disconnected successfully";
            await Clients.Others.SendAsync("Disconnect", "s");
        }

        public async Task SendFollow(string id)
        {
            await Clients.Users(new String[] { id }).SendAsync("ReceiveNotification");
        }



        //public async Task SendFollow(string id)
        //{
        //    await Clients.Users(new String[] { id }).SendAsync("ReceiveNotification");
        //}

    }
}
