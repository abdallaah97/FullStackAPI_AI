using System.ComponentModel.DataAnnotations.Schema;

namespace FullStackAPI_AI.Entities
{
    public class Address
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string AddressLine { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
