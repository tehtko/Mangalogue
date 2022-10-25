using Mangalogue.Data;
using Mangalogue.Entities;
using Microsoft.EntityFrameworkCore;

namespace Mangalogue.Services
{
    public class UserService
    {
        private readonly MDataContext _context;
        public UserService(MDataContext context)
        {
            _context = context;
        }

        internal bool AddUser(User user)
        {
            // check to see if the username already exists
            if (_context.Users.Any(x=>x.Username==user.Username))
                return false;

            // check to see if the email already exists
            if (_context.Users.Any(x => x.Email == user.Email))
                return false;

            try
            {
                _context.Users.Add(user);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        internal bool Login(User user)
        {
            // check to see if an entity with matching username and password exists
            if (_context.Users.Any(x => x.Username == user.Username))
                return true;

            // check to see if an entity with matching email and password exists
            else if (_context.Users.Any(x => x.Email == user.Email))
                return true;

            else
                return false;
        }
    }
}
