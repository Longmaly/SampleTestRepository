using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SampleTest
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext appDbContext;

        public UserRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<IEnumerable<UserModel>> GetUsers()
        {
            return await appDbContext.Users.ToListAsync();
        }

        public async Task<UserModel> GetUser(Guid userId)
        {
            return await appDbContext.Users
                .FirstOrDefaultAsync(e => e.Id == userId);
        }

        public async Task<UserModel> AddUser(UserModel user)
        {
            var result = await appDbContext.Users.AddAsync(user);
            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<UserModel> UpdateUser(UserModel user)
        {
            var result = await appDbContext.Users
                .FirstOrDefaultAsync(e => e.Id == user.Id);

            if (result != null)
            {
                result.FirstName = user.FirstName;
                result.LastName = user.LastName;
                result.Addresses = user.Addresses;

                await appDbContext.SaveChangesAsync();

                return result;
            }

            return null;
        }

        public async void DeleteUser(Guid userId)
        {
            var result = await appDbContext.Users
                .FirstOrDefaultAsync(e => e.Id == userId);
            if (result != null)
            {
                appDbContext.Users.Remove(result);
                await appDbContext.SaveChangesAsync();
            }
        }
    }
}

