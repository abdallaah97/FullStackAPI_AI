using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace FullStackAPI_AI.Entities
{
    [Index(nameof(PersonProfileId), IsUnique = true)]
    [Index(nameof(CompanyProfileId), IsUnique = true)]
    public class User
    {
        //Primary Key (Identity) => Unique,Not NULL,Auto Increment
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public DateTime CretaedAt { get; set; }
        public UserType Type { get; set; }
        public int? PersonProfileId { get; set; }
        [ForeignKey("PersonProfileId")]
        public PersonProfile PersonProfile { get; set; }
        public int? CompanyProfileId { get; set; }
        [ForeignKey("CompanyProfileId")]
        public CompanyProfile CompanyProfile { get; set; }
    }

    public enum UserType
    {
        Person = 1,
        Company = 2
    }
}
