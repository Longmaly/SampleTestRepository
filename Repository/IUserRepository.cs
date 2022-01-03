using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleTest
{
    public interface IUserRepository
    {
        Task<IEnumerable<UserModel>> GetUsers();
        Task<UserModel> GetUser(Guid userId);
        Task<UserModel> AddUser(UserModel user);
        Task<UserModel> UpdateUser(UserModel user);
        void DeleteUser(Guid userId);
    }
}
