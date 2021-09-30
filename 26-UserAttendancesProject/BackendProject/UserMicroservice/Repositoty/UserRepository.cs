using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserMicroservice.Db;
using UserMicroservice.Entities;
using UserMicroservice.Events;
using UserMicroservice.Extensions;

namespace UserMicroservice.Repositoty
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IUserEvent _userEvent;

        public UserRepository(ApplicationDbContext context, IUserEvent userEvent)
        {
            _context = context;
            _userEvent = userEvent;
        }

        public User Authenticate(User user)
        {
            User currentUser = this.GetUserByNickname(user.Nickname);
            bool verified = currentUser != null && BCrypt.Net.BCrypt.Verify(user.Password, currentUser.Password);
            if (verified)
            {
                return currentUser;
            }
            else
            {
                return null;
            }
           
        }

        public void CreateUser(User user)
        {
            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public async Task DeleteUser(int Id)
        {
            var user = this.GetUserById(Id);
            if(user is not null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
                await _userEvent.DeleteUserEvent(Id);
            }
        }

        public List<User> GetAll(string Nickname = "", string Name = "")
        {
            return _context.Users
                .WhereIf(!Nickname.Equals(""), p => p.Nickname.Contains(Nickname))
                .WhereIf(!Name.Equals(""), p => p.Name.Contains(Name))
                .ToList();
        }

        public User GetUserById(int Id)
        {
            return _context.Users.Where(p => p.Id == Id).FirstOrDefault();
        }

        public User GetUserByNickname(string username)
        {
            return _context.Users.Where(user => user.Nickname.Equals(username)).FirstOrDefault();
        }
    }
}
