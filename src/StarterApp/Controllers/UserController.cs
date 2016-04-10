using System;
using System.Collections.Generic;
using GenFu;
using Microsoft.AspNet.Cors;
using Microsoft.AspNet.Mvc;
using StarterApp.Models;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace StarterApp.Controllers
{
    [EnableCors("LocalhostPolicy")]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        [FromServices]
        public IUserRepository Users { get; set; }

        // GET: api/users
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return Users.GetAll();
        }

        // GET api/users/id
        [HttpGet("{id}", Name = "GetUser")]
        public IActionResult Get(string id)
        {
            User user = Users.Find(id);
            if (user == null)
            {
                return this.HttpNotFound();
            }
            return this.Ok(user);
        }

        // POST api/users
        [HttpPost]
        public IActionResult Create([FromBody]User user)
        {
            if (user == null)
            {
                return this.HttpBadRequest();
            }
            user.Id = Guid.NewGuid();
            Users.Update(user);
            return CreatedAtRoute("GetUser", new { controller = "User", id = user.Id.ToString() }, user);
        }

        // PUT api/users/5
        [HttpPut("{id}")]
        public IActionResult Update(string id, [FromBody]User user)
        {
            if (user == null)
            {
                return this.HttpBadRequest();
            }
            User existingUser = Users.Find(id);
            if (existingUser == null) return this.HttpNotFound();
            Users.Update(user);
            return new NoContentResult();
        }

        // DELETE api/users/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            Users.Remove(id);
        }
    }
}
