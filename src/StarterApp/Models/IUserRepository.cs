using System.Collections.Generic;

namespace StarterApp.Models
{
    public interface IUserRepository
    {
        void Add(User user);
        IEnumerable<User> GetAll();
        User Find(string key);
        User Remove(string key);
        void Update(User item);
    }
}
