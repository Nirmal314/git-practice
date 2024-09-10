using Exploration.Models;

namespace Exploration.Interfaces
{
    public interface IUsers
    {
        public List<User> GetUsers();
        public User? GetUser(int id);
        public bool CreateUser(User user);
        public User? UpdateUser(int id, User user);
        public bool DeleteUser(int id);
    }
}
