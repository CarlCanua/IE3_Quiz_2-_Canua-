namespace ITQ2_BSIT32E1_SOLIS_SOPHIA_CASSANDRA.Models.UserGroup
{
    public class GetUserGroupResponse
    {
        public List<GetUserGroupItem> UserGroups { get; set; } = new List<GetUserGroupItem>();
    }

    public class GetUserGroupItem
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int UserCount { get; set; }
    }
}
