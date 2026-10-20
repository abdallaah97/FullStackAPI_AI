namespace FullStackAPI_AI.Entities
{
    public class User
    {
        //Primary Key (Identity) => Unique,Not NULL,Auto Increment
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public DateTime CretaedAt { get; set; }
    }
}
