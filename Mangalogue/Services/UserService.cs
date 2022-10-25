using Mangalogue.Data;
using Mangalogue.Entities;
using Mangalogue.Helpers;
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
            if (_context.Users.Any(x => x.Username == user.Username))
                return false;

            // check to see if the email already exists
            if (_context.Users.Any(x => x.Email == user.Email))
                return false;

            try
            {
                user.Password = Encryption.HashPassword(user.Password);
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
            user.Password = Encryption.UnhashPassword(user.Password, user.salt);

            // check to see if an entity with matching username and password exists
            if (_context.Users.Any(x => x.Username == user.Username && x.Password == user.Password))
                return true;

            // check to see if an entity with matching email and password exists
            else if (_context.Users.Any(x => x.Email == user.Email && x.Password == user.Password))
                return true;

            else
                return false;
        }
    }
}
