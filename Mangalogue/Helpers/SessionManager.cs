using Mangalogue.Entities;
using Mangalogue.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Mangalogue.Helpers
{
    public class SessionManager
    {
#pragma warning disable 8602, 8603, 8604
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserService _userService;

        public SessionManager(IHttpContextAccessor httpContextAccessor, UserService userService)
        {
            _httpContextAccessor = httpContextAccessor;
            _userService = userService;
        }

        public User GetUserSession()
        {
            try
            {
                return JsonConvert.DeserializeObject<User>(
                    _httpContextAccessor.HttpContext.Session.GetString("User"));
            }
            catch (Exception)
            {
                return null;
            }
        }

        public void CreateUserSession(User user)
        {
            try
            {
                _httpContextAccessor.HttpContext.Session.SetString("User",
                    JsonConvert.SerializeObject(_userService.GetUserByLogin(user.Username)));
            }
            catch (Exception)
            {
                _httpContextAccessor.HttpContext.Session.SetString(
                    "Error", "An error occured retrieving your profile");
            }
        }
    }
#pragma warning restore 8602, 8603, 8604
}