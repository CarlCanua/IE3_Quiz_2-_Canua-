// Data/UserRepository.cs
namespace ITQ2_BSIT32E1_SOLIS_SOPHIA_CASSANDRA.Data
{
    public static class UserRepository
    {
        // ---------- Users ----------
        public static List<User> GetUsers()
        {
            return DataStore.Users;
        }

        public static User? GetUserById(int id)
        {
            return DataStore.Users.FirstOrDefault(u => u.Id == id);
        }

        public static User AddUser(string name, string email)
        {
            var user = new User
            {
                Id = DataStore.Users.Count == 0 ? 1 : DataStore.Users.Max(u => u.Id) + 1,
                Name = name,
                Email = email
            };
            DataStore.Users.Add(user);
            return user;
        }

        public static bool UpdateUser(int id, string name, string email)
        {
            var user = GetUserById(id);
            if (user == null)
            {
                return false;
            }
            user.Name = name;
            user.Email = email;
            return true;
        }

        public static bool DeleteUser(int id)
        {
            var user = GetUserById(id);
            if (user == null)
            {
                return false;
            }
            DataStore.Users.Remove(user);

            // also remove the user from any group
            foreach (var group in UserGroup.UserGroups)
            {
                group.Users.RemoveAll(u => u.Id == id);
            }
            return true;
        }

        // ---------- User groups ----------
        public static List<UserGroup> GetUserGroups()
        {
            return UserGroup.UserGroups;
        }

        public static UserGroup? GetUserGroupById(int id)
        {
            return UserGroup.UserGroups.FirstOrDefault(g => g.Id == id);
        }

        // returns the ids that do not exist (empty list = all valid)
        public static List<int> FindMissingUserIds(IEnumerable<int> userIds)
        {
            return userIds.Distinct().Where(id => GetUserById(id) == null).ToList();
        }

        public static UserGroup AddUserGroup(string name, IEnumerable<int> userIds)
        {
            var group = new UserGroup
            {
                Id = UserGroup.UserGroups.Count == 0 ? 1 : UserGroup.UserGroups.Max(g => g.Id) + 1,
                Name = name,
                Users = userIds.Distinct().Select(id => GetUserById(id)!).ToList()
            };
            UserGroup.UserGroups.Add(group);
            return group;
        }

        public static bool UpdateUserGroup(int id, string name, IEnumerable<int> userIds)
        {
            var group = GetUserGroupById(id);
            if (group == null)
            {
                return false;
            }
            group.Name = name;
            group.Users = userIds.Distinct().Select(uid => GetUserById(uid)!).ToList();
            return true;
        }

        public static bool DeleteUserGroup(int id)
        {
            var group = GetUserGroupById(id);
            if (group == null)
            {
                return false;
            }
            UserGroup.UserGroups.Remove(group);
            return true;
        }
    }
}