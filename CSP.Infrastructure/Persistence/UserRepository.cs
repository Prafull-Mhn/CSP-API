using CSP.Application.Common.Interfaces;
using CSP.Domain.Entities;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSP.Infrastructure.Persistence
{
    public class UserRepository : IUserRepository
    {
        private readonly SqlConnection _connection;

        public UserRepository(IConfiguration configuration)
        {
            _connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            var query = "SELECT * FROM UserPersonalInfo WHERE UserId = @Id";
            return await _connection.QueryFirstOrDefaultAsync<User>(query, new { Id = id });
        }

        public async Task<string> GetUserStatus(string useremailId, string password)
        {
            if (useremailId == "naveen@paisapay.com")
                if (password == "1234")
                    return "User Logged";
                else
                    return "Invalid Password";
            else
                return "Invalid User";
            //var query = "SELECT * FROM UserPersonalInfo WHERE UserId = @Id";
            //return await _connection.QueryFirstOrDefaultAsync<User>(query, new { Id = id });
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            var query = "SELECT * FROM Users";
            return await _connection.QueryAsync<User>(query);
        }

        public async Task<int> CreateUserAsync(User user)
        {
            var query = @"
                INSERT INTO Users (Id, Name, Email, PhoneNumber, Address, CityId, TenantId, IsActive, CreatedDate, CreatedBy)
                VALUES (@Id, @Name, @Email, @PhoneNumber, @Address, @CityId, @TenantId, @IsActive, @CreatedDate, @CreatedBy)";
            await _connection.ExecuteAsync(query, user);
            return user.UserId;
        }

        public async Task UpdateUserAsync(User user)
        {
            var query = @"
                UPDATE Users
                SET Name = @Name, Email = @Email, PhoneNumber = @PhoneNumber, Address = @Address, LastModifiedDate = @LastModifiedDate, LastModifiedBy = @LastModifiedBy
                WHERE Id = @Id";
            await _connection.ExecuteAsync(query, user);
        }

        public async Task DeleteUserAsync(int id)
        {
            var query = "DELETE FROM Users WHERE Id = @Id";
            await _connection.ExecuteAsync(query, new { Id = id });
        }
    }

}
