using System.ComponentModel.DataAnnotations;

namespace ITQ2_BSIT32E1_SOLIS_SOPHIA_CASSANDRA.Models.Users
{
    public class EditUsersRequest
    {
        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
    }
}
