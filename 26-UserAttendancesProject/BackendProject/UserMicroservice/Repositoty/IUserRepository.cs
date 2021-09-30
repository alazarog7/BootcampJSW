using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserMicroservice.Entities;

namespace UserMicroservice.Repositoty
{
    public interface IUserRepository
    {
        void CreateUser(User user);
        Task DeleteUser(int Id);
        List<User> GetAll(string nickname = "", string name = "");
        User GetUserById(int Id);
        User GetUserByNickname(string username);
        User Authenticate(User user);
    }
}
