using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace FullStackAPI_AI.Entities
{
    [Index(nameof(UserId), nameof(TitleId), IsUnique = true)]

    public class UserTitle
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
        public int TitleId { get; set; }
        [ForeignKey("TitleId")]
        public Title Title { get; set; }
    }
}
