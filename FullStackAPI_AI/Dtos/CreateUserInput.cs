using FullStackAPI_AI.Entities;

namespace FullStackAPI_AI.Dtos
{
    public class CreateUserInput
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public UserType Type { get; set; } // Person - 1 , Company - 2
        public CreateUserPersonInput? Person { get; set; }
        public CreateUserCompanyInput? Company { get; set; }
    }

    public class CreateUserPersonInput
    {
        public DateTime BirthDate { get; set; }
        public string NationalId { get; set; }
    }

    public class CreateUserCompanyInput
    {
        public string LicinceNumber { get; set; }
    }
}
