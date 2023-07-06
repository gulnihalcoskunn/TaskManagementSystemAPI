namespace TaskManagementSystemAPI.Models
{
    public class User
    {
        public Guid USER_ID { get; set; }
        public string? USERNAME { get; set; }
        public string? PASSWORD { get; set; }
        public string? EMAIL { get; set; }
    }
}
