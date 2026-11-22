using ITQ2_BSIT32E1_SOLIS_SOPHIA_CASSANDRA.Data;
using ITQ2_BSIT32E1_SOLIS_SOPHIA_CASSANDRA.Models.UserGroup;
using Microsoft.AspNetCore.Mvc;

namespace ITQ2_BSIT32E1_SOLIS_SOPHIA_CASSANDRA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserGroupController : ControllerBase
    {
        // GET: api/usergroup
        [HttpGet]
        public IActionResult Get()
        {
            var response = new GetUserGroupResponse();
            foreach (var group in UserRepository.GetUserGroups())
            {
                response.UserGroups.Add(new GetUserGroupItem
                {
                    Id = group.Id,
                    Name = group.Name,
                    UserCount = group.Users.Count
                });
            }
            return Ok(response);
        }

        // GET: api/usergroup/5
        [HttpGet("{id}", Name = "GetUserGroupById")]
        public IActionResult GetById(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            var group = UserRepository.GetUserGroupById(id);
            if (group == null)
            {
                return NotFound();
            }

            return Ok(ToByIdResponse(group));
        }

        // POST: api/usergroup  -> 201 Created + Location header
        [HttpPost]
        public IActionResult Post([FromBody] CreateUserGroupRequest request)
        {
            var missing = UserRepository.FindMissingUserIds(request.UserIds);
            if (missing.Count > 0)
            {
                return BadRequest($"User id(s) not found: {string.Join(", ", missing)}");
            }

            var newGroup = UserRepository.AddUserGroup(request.Name, request.UserIds);
            return CreatedAtRoute("GetUserGroupById", new { id = newGroup.Id }, ToByIdResponse(newGroup));
        }

        // PUT: api/usergroup/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] EditUserGroupRequest request)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            var missing = UserRepository.FindMissingUserIds(request.UserIds);
            if (missing.Count > 0)
            {
                return BadRequest($"User id(s) not found: {string.Join(", ", missing)}");
            }

            if (!UserRepository.UpdateUserGroup(id, request.Name, request.UserIds))
            {
                return NotFound();
            }
            return NoContent();
        }

        // DELETE: api/usergroup/5  -> 404 if not found, 204 if deleted
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (!UserRepository.DeleteUserGroup(id))
            {
                return NotFound();
            }
            return NoContent();
        }

        private static GetUserGroupByIdResponse ToByIdResponse(UserGroup group)
        {
            return new GetUserGroupByIdResponse
            {
                Id = group.Id,
                Name = group.Name
            };
        }
    }
}
