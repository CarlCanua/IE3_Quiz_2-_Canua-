// Data/UserGroup.cs
namespace ITQ2_BSIT32E1_SOLIS_SOPHIA_CASSANDRA.Data
{
    public class UserGroup
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<User> Users { get; set; } = new List<User>();

        // static list of user groups (10 groups)
        public static List<UserGroup> UserGroups = new List<UserGroup>
        {
            new UserGroup { Id = 1,  Name = "Admins",     Users = new List<User> { DataStore.Users[0], DataStore.Users[1] } },
            new UserGroup { Id = 2,  Name = "Editors",    Users = new List<User> { DataStore.Users[2], DataStore.Users[3], DataStore.Users[4] } },
            new UserGroup { Id = 3,  Name = "Viewers",    Users = new List<User> { DataStore.Users[5], DataStore.Users[6], DataStore.Users[7], DataStore.Users[8], DataStore.Users[9] } },
            new UserGroup { Id = 4,  Name = "Developers", Users = new List<User> { DataStore.Users[0], DataStore.Users[3], DataStore.Users[5] } },
            new UserGroup { Id = 5,  Name = "Testers",    Users = new List<User> { DataStore.Users[1], DataStore.Users[4] } },
            new UserGroup { Id = 6,  Name = "Designers",  Users = new List<User> { DataStore.Users[2], DataStore.Users[6] } },
            new UserGroup { Id = 7,  Name = "Support",    Users = new List<User> { DataStore.Users[7], DataStore.Users[8] } },
            new UserGroup { Id = 8,  Name = "Managers",   Users = new List<User> { DataStore.Users[0], DataStore.Users[2] } },
            new UserGroup { Id = 9,  Name = "Interns",    Users = new List<User> { DataStore.Users[8], DataStore.Users[9] } },
            new UserGroup { Id = 10, Name = "Guests",     Users = new List<User> { DataStore.Users[9] } }
        };
    }
}