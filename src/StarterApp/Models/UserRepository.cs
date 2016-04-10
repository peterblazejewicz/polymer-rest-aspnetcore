using System;
using System.Collections.Generic;
using System.Linq;
using GenFu;

namespace StarterApp.Models
{
    public class UserRepository: IUserRepository
    {

        public void Add(User user)
        {
            user.Id = Guid.NewGuid();
            Users.Add(user);
        }

        public User Find(string key)
        {
            Guid findId = new Guid(key);
            return Users.Find(u => u.Id == findId);
        }

        public IEnumerable<User> GetAll()
        {
            return Users;
        }

        public User Remove(string key)
        {
            Guid findId = new Guid(key);
            User user = Users.Find(u => u.Id == findId);
            if(user != null) {
              Users.Remove(user);
            }
            return user;
        }

        public void Update(User user)
        {
            User existingUser = Users.Find(u => u.Id == user.Id);
            var index = Users.IndexOf(existingUser);
            if(index != -1) Users[index] = user;
        }

        public List<User> Users { get {
          if(UserRepository._users == null) {
            A.Configure<User>()
                .Fill(u => u.Email)
                .AsEmailAddressForDomain("example.com");

            _users = A.ListOf<User>();
            _users.All(u => { u.Id = Guid.NewGuid(); return true;});
          }
          return _users;
        }}
        private static List<User> _users = null;
    }
}
