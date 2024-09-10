using Dapper;
using Exploration.Interfaces;
using Exploration.Models;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using System.Data;
using System.Data.Common;

namespace Exploration.Services
{
    public class UserService : IUsers
    {
        private readonly IMongoCollection<Movie> collection;
        private readonly IDbConnection _connection;

        public UserService(IDbConnection connection, MongoDbContext mcontext)
        {
            _connection = connection;
            collection = mcontext.GetCollection<Movie>("movies");
        }
        public List<User> GetUsers()
        {
            string sql = "SELECT * FROM Users";

            return _connection.Query<User>(sql).ToList();
        }

        public User? GetUser(int id)
        {
            string sql = "SELECT * FROM Users WHERE UserId = @Id";

            User? user = _connection.QuerySingleOrDefault<User>(sql, new { Id = id });
            return user;
        }


        public bool CreateUser(User user)
        {
            var sql = @$"INSERT INTO Users 
                    (Email, BirthDate, ContactNo, Fullname, Type, CreatedOn, UpdatedOn, IsDeleted) 
                    VALUES (@Email, @BirthDate, @ContactNo, @Fullname, @Type, '{DateTime.Now}', '{DateTime.Now}', 0)";

            int rowsAffected = _connection.Execute(sql, user);

            if (rowsAffected > 0)
            {
                return true;
            }
            return false;
        }
        public User? UpdateUser(int id, User user)
        {
            if (!UserExists(id) || id != user.UserId)
            {
                return null;
            }

            string sql = @$"UPDATE Users
                        SET Email = @Email,
                            BirthDate = @BirthDate,
                            ContactNo = @ContactNo,
                            Fullname = @Fullname,
                            Password = @Password,
                            Type = @Type,
                            UpdatedOn = '{DateTime.Now}'
                        WHERE UserId = @UserId;
                        ";

            int rowsAffected = _connection.Execute(sql, user);

            if (rowsAffected > 0)
            {
                return GetUser(id)!;
            }

            return null;
        }

        public bool DeleteUser(int id)
        {
            if (!UserExists(id))
            {
                return false;
            }

            string sql = @"UPDATE Users
                            SET IsDeleted = 1
                            WHERE UserId = @Id;
                        ";

            int rowsAffected = _connection.Execute(sql, new { Id = id });

            if (rowsAffected > 0)
            {
                return true;
            }

            return false;
        }

        private bool UserExists(int id)
        {
            var sql = "SELECT COUNT(1) FROM Users WHERE UserId = @UserId";
            int count = _connection.ExecuteScalar<int>(sql, new { UserId = id });
            return count > 0;
        }
    }
}
