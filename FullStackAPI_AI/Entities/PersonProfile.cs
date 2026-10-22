using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace FullStackAPI_AI.Entities
{
    [Index(nameof(NationalId), IsUnique = true)]
    public class PersonProfile
    {
        public int Id { get; set; }
        public DateTime BirthDate { get; set; }
        public string NationalId { get; set; }
    }
}
