using System.Collections.Generic;
using Microsoft.AspNet.Mvc;
using PolymerApp.API.Models;
using GenFu;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace PolymerApp.API.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        // GET: api/users
        [HttpGet]
        public IEnumerable<User> Get()
        {
            var users = A.ListOf<User>();
            return users;
        }

        // GET api/users/username
        [HttpGet("{username}")]
        public User Get(string username)
        {
            var user = A.New<User>();
            return user;
        }

    }
}
