using Mangalogue.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Mangalogue.Helpers
{
    public class SessionManager
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public SessionManager(IHttpContextAccessor httpContextAccessor) =>
            _httpContextAccessor = httpContextAccessor;

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
                _httpContextAccessor.HttpContext.Session.SetString("user", JsonConvert.SerializeObject(user));
            }
            catch (Exception) {  }
        }
    }
}
