using ITQ2_BSIT32E1_SOLIS_SOPHIA_CASSANDRA.Data;
using ITQ2_BSIT32E1_SOLIS_SOPHIA_CASSANDRA.Models.Users;
using Microsoft.AspNetCore.Mvc;

namespace ITQ2_BSIT32E1_SOLIS_SOPHIA_CASSANDRA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        // GET: api/users
        [HttpGet]
        public IActionResult Get()
        {
            var response = new GetUsersResponse();
            foreach (var user in UserRepository.GetUsers())
            {
                response.Users.Add(new GetUsersItem
                {
                    Id = user.Id,
                    Name = user.Name
                });
            }
            return Ok(response);
        }

        // GET: api/users/5
        [HttpGet("{id}", Name = "GetUserById")]
        public IActionResult GetById(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            var user = UserRepository.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(new GetUsersByIdResponse
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email
            });
        }

        // POST: api/users  -> 201 Created + Location header
        [HttpPost]
        public IActionResult Post([FromBody] CreateUsersRequest request)
        {
            var newUser = UserRepository.AddUser(request.Name, request.Email);

            return CreatedAtRoute("GetUserById", new { id = newUser.Id }, new GetUsersByIdResponse
            {
                Id = newUser.Id,
                Name = newUser.Name,
                Email = newUser.Email
            });
        }

        // PUT: api/users/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] EditUsersRequest request)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            if (!UserRepository.UpdateUser(id, request.Name, request.Email))
            {
                return NotFound();
            }
            return NoContent();
        }

        // DELETE: api/users/5  -> 404 if not found, 204 if deleted
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (!UserRepository.DeleteUser(id))
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
