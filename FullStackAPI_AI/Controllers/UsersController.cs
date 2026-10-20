using FullStackAPI_AI.Context;
using FullStackAPI_AI.Dtos;
using FullStackAPI_AI.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
            var user = new User
            {
                Name = input.Name,
                Phone = input.Phone,
                CretaedAt = DateTime.Now
            };

            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();

            var result = new UserOutput
            {
                Id = user.Id,
                Name = user.Name,
                Phone = user.Phone
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
            var user = _dbContext.Users.FirstOrDefault(x => x.Id == id);

            var result = new UserOutput
            {
                Id = user.Id,
                Name = user.Name,
                Phone = user.Phone
            };

            return result;
        }

        /*[HttpGet("GetUsers")]
        public List<UserOutput> GetUsers()
        {
            var users = _dbContext.Users.ToList();

            return users;
        }*/

        [HttpDelete("DeleteUser/{id}")]
        public void DeleteUser(int id)
        {
            var user = _dbContext.Users.FirstOrDefault(x => x.Id == id);
            _dbContext.Remove(user);
            _dbContext.SaveChanges();
        }
    }
}
