using FullStackAPI_AI.Entities;

namespace FullStackAPI_AI.Dtos
{
    public class UserOutput
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public UserType Type { get; set; }
        public UserPersonOutput Person { get; set; }
        public UserCompanyOutput Company { get; set; }
    }

    public class UserPersonOutput
    {
        public int Id { get; set; }
        public DateTime BirthDate { get; set; }
        public string NationalId { get; set; }
    }

    public class UserCompanyOutput
    {
        public int Id { get; set; }
        public string LicinceNumber { get; set; }
    }
}
