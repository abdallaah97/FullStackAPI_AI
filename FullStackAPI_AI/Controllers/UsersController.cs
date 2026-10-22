using FullStackAPI_AI.Context;
using FullStackAPI_AI.Dtos;
using FullStackAPI_AI.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FullStackAPI_AI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly AppDbContext _dbContext;
        public UsersController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost("CreateUser")]
        public UserOutput CreateUser([FromBody] CreateUserInput input)
        {
            var person = new PersonProfile();
            var company = new CompanyProfile();
            if (input.Type == UserType.Person)
            {
                person = new PersonProfile
                {
                    BirthDate = input.Person.BirthDate,
                    NationalId = input.Person.NationalId,
                };

                _dbContext.PersonProfiles.Add(person);
                _dbContext.SaveChanges();
            }
            else
            {
                company = new CompanyProfile
                {
                    LicinceNumber = input.Company.LicinceNumber,
                };

                _dbContext.CompanyProfiles.Add(company);
                _dbContext.SaveChanges();
            }

            var user = new User
            {
                Name = input.Name,
                Phone = input.Phone,
                CretaedAt = DateTime.Now,
                Password = "21322131",
                Type = input.Type,
                PersonProfileId = input.Type == UserType.Person ? person.Id : null,
                CompanyProfileId = input.Type == UserType.Company ? company.Id : null
            };

            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();

            var result = new UserOutput
            {
                Id = user.Id,
                Name = user.Name,
                Phone = user.Phone,
                Company = input.Type == UserType.Company ? new UserCompanyOutput
                {
                    Id = company.Id,
                    LicinceNumber = company.LicinceNumber
                } : null,
                Person = input.Type == UserType.Person ? new UserPersonOutput
                {
                    Id = person.Id,
                    BirthDate = person.BirthDate,
                    NationalId = person.NationalId
                } : null
            };

            return result;
        }

        [HttpPut("UpdateUser/{id}")]
        public UserOutput UpdateUser(int id, [FromBody] CreateUserInput input)
        {
            var user = _dbContext.Users.FirstOrDefault(x => x.Id == id);
            user.Name = input.Name;
            user.Phone = input.Phone;
            _dbContext.Users.Update(user);

            if (user.Type == UserType.Person)
            {
                var person = _dbContext.PersonProfiles.FirstOrDefault(x => x.Id == user.PersonProfileId);
                person.BirthDate = input.Person.BirthDate;
                person.NationalId = input.Person.NationalId;

                _dbContext.PersonProfiles.Update(person);
            }
            else
            {
                var compnay = _dbContext.CompanyProfiles.FirstOrDefault(x => x.Id == user.CompanyProfileId);
                compnay.LicinceNumber = input.Company.LicinceNumber;

                _dbContext.CompanyProfiles.Update(compnay);
            }

            _dbContext.SaveChanges();

            var result = new UserOutput
            {
                Id = user.Id,
                Name = user.Name,
                Phone = user.Phone
            };

            return result;
        }

        [HttpPatch("UpdateUserPhone/{id}")]
        public UserOutput UpdateUserPhone(int id, [FromBody] UpdateUserPhoneInput input)
        {
            var user = _dbContext.Users.FirstOrDefault(x => x.Id == id);
            user.Phone = input.Phone;

            _dbContext.Users.Update(user);
            _dbContext.SaveChanges();

            var result = new UserOutput
            {
                Id = user.Id,
                Name = user.Name,
                Phone = user.Phone
            };

            return result;
        }

        [HttpGet("GetUser/{id}")]
        public UserOutput GetUser(int id)
        {
            var result = new UserOutput();
            var user = _dbContext.Users.FirstOrDefault(x => x.Id == id);
            result = new UserOutput
            {
                Id = user.Id,
                Name = user.Name,
                Phone = user.Phone,
                Type = user.Type
            };
            if (user.Type == UserType.Person)
            {
                var person = _dbContext.PersonProfiles.FirstOrDefault(x => x.Id == user.PersonProfileId);
                result.Person = new UserPersonOutput
                {
                    Id = person.Id,
                    BirthDate = person.BirthDate,
                    NationalId = person.NationalId
                };
            }
            else
            {
                var compnay = _dbContext.CompanyProfiles.FirstOrDefault(x => x.Id == user.CompanyProfileId);
                result.Company = new UserCompanyOutput
                {
                    Id = compnay.Id,
                    LicinceNumber = compnay.LicinceNumber
                };
            }

            return result;
        }

        [HttpGet("GetUsers")]
        public List<UserOutput> GetUsers()
        {
            var reult = new List<UserOutput>();
            var users = _dbContext.Users
                .Include(x => x.PersonProfile)
                .Include(x => x.CompanyProfile).ToList();

            reult = users.Select(x => new UserOutput
            {
                Id = x.Id,
                Name = x.Name,
                Phone = x.Phone,
                Type = x.Type,
                Person = x.Type == UserType.Person ? new UserPersonOutput
                {
                    Id = x.PersonProfile.Id,
                    BirthDate = x.PersonProfile.BirthDate,
                    NationalId = x.PersonProfile.NationalId
                } : null,
                Company = x.Type == UserType.Company ? new UserCompanyOutput
                {
                    Id = x.CompanyProfile.Id,
                    LicinceNumber = x.CompanyProfile.LicinceNumber,
                } : null
            }).ToList();

            return reult;
        }

        [HttpDelete("DeleteUser/{id}")]
        public void DeleteUser(int id)
        {
            var user = _dbContext.Users.FirstOrDefault(x => x.Id == id);
            if (user.Type == UserType.Person)
            {
                var person = _dbContext.PersonProfiles.FirstOrDefault(x => x.Id == user.PersonProfileId);
                _dbContext.PersonProfiles.Remove(person);
            }
            else
            {
                var compnay = _dbContext.CompanyProfiles.FirstOrDefault(x => x.Id == user.CompanyProfileId);
                _dbContext.CompanyProfiles.Remove(compnay);
            }
            _dbContext.Users.Remove(user);
            _dbContext.SaveChanges();
        }
    }
}
