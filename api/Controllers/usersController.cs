using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Interfaces;
using api.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class usersController : ControllerBase
    {
        // GET: api/users
        [EnableCors("AnotherPolicy")]
        [HttpGet]
        public List<User> Get()
        {
            IGetAllUsers allUsers = new GetAllUserData(); 
            return allUsers.GetAllUsers();
        }
        [EnableCors("AnotherPolicy")]
        [Route("login/{username}/{password}")]
        public User AuthenticateUser(string username, string password)
        {
            IAuthenticateUser userObject = new GetAllUserData(); 
            return userObject.AuthenticateUser(username, password); 
           
        }

        // GET: api/users/5
        [EnableCors("AnotherPolicy")]
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/users
        [EnableCors("AnotherPolicy")]
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/users/5
        [EnableCors("AnotherPolicy")]
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/users/5
        [EnableCors("AnotherPolicy")]
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
