using Mangalogue.Entities;
using Mangalogue.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Mangalogue.Helpers
{
    public class SessionManager
    {
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
                return JsonConvert.DeserializeObject<User>(_httpContextAccessor.HttpContext.Session.GetString("user"));
            }
            catch(Exception) { return null; }
        }

        public void CreateUserSession(User user)
        {
            try
            {
                var _user = _userService.GetUserByEmail(user.Email);
                _httpContextAccessor.HttpContext.Session.SetString("user", JsonConvert.SerializeObject(_user));
            }
            catch (Exception) {  }
        }
    }
}
