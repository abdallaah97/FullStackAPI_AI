using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace FullStackAPI_AI.Entities
{
    [Index(nameof(LicinceNumber), IsUnique = true)]
    public class CompanyProfile
    {
        public int Id { get; set; }
        public string LicinceNumber { get; set; }
    }
}
