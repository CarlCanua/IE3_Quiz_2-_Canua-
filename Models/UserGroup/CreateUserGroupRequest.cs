using System.ComponentModel.DataAnnotations;

namespace ITQ2_BSIT32E1_SOLIS_SOPHIA_CASSANDRA.Models.UserGroup
{
    public class CreateUserGroupRequest
    {
        [Required]
        public string Name { get; set; } = string.Empty;

        public List<int> UserIds { get; set; } = new List<int>();
    }
}
