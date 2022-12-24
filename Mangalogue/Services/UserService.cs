using Mangalogue.Data;
using Mangalogue.Entities;
using Mangalogue.Helpers;
using Mangalogue.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;
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

            // check to see if the email already exists (if provided)
            if(user.Email is not null)
                if (_context.Users.Any(x => x.Email == user.Email))
                    return false;

            try
            {
                // get the salted password and salt from HashPassword method
                var strings = Encryption.HashPassword(user.Password);

                // and update the model with the data
                user.Password = strings[0];
                user.Salt = strings[1];

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
            {
                // if there is a match, check to see if the password in the database
                // matches the user provided password
                var _user = _context.Users.FirstOrDefault(x => x.Username == user.Username);
                if (Encryption.HashPassword(user.Password, _user.Salt) == _user.Password)
                    return true;
                else
                    return false;
            }

            // check to see if an entity with the given email exists
            else if (_context.Users.Any(x => x.Email == user.Email))
            {
                // if there is a match, check to see if the password in the database
                // matches the user provided password
                var _user = _context.Users.FirstOrDefault(x => x.Email == user.Email);
                if (Encryption.HashPassword(user.Password, _user.Salt) == _user.Password)
                    return true;
                else
                    return false;
            }

            return false;
        }

        public User GetUserById(int id)
        {
            // will return null collections for Posts and Favorites if not found. handle this in the controller
                return _context.Users.Where(u => u.Id == id)
                .Include(u => u.Posts)
                .Include(u => u.Favorites)
                .FirstOrDefault();
        }

        public User GetUserByEmail(string email)
        {
            return _context.Users.Where(u => u.Email == email)
                .Include(u => u.Posts)
                .Include(u => u.Favorites)
                .FirstOrDefault();
        }
    }
}
