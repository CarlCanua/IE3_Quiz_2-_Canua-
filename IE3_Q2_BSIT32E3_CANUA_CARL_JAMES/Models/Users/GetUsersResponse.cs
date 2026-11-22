namespace ITQ2_BSIT32E1_SOLIS_SOPHIA_CASSANDRA.Models.Users
{
    public class GetUsersResponse
    {
        public List<GetUsersItem> Users { get; set; } = new List<GetUsersItem>();
    }

    public class GetUsersItem
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
