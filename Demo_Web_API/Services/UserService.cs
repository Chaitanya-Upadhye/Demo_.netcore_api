using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Demo_Web_API.Authorization_Helpers;
using Demo_Web_API.Entities;
using Demo_Web_API.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Demo_Web_API.DBModels;
using Demo_Web_API.Data;

namespace Demo_Web_API.Services
{
    public class UserService:IUserService
    {

        private readonly IDemoRepo _repository;
        private readonly AppSettings _appSettings;


        
        private List<UserDTO> _users = new List<UserDTO>
        {
            new UserDTO { Id = "1", FirstName = "Chaitanya", LastName = "Upadhye", Username = "test", Password = "test" },
                        new UserDTO { Id = "1", FirstName = "Virat", LastName = "kohli", Username = "virat", Password = "test" }

        };


        public UserService(IOptions<AppSettings> appSettings, IDemoRepo repository)
        {
            _appSettings = appSettings.Value;
            _repository = repository;

        }

        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {
            try
            {
                var user = _repository.GetUser(model);
                //  var user = _users.SingleOrDefault(x => x.Username == model.Username && x.Password == model.Password);

                // return null if user not found
                if (user == null) return null;

                UserDTO userResponse = new UserDTO()
                {
                    Username = user.UserName,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Id = user.Id.ToString()
                };

                // authentication successful so generate jwt token
                var token = generateJwtToken(userResponse);

                return new AuthenticateResponse(userResponse, token);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<UserDTO> GetAll()
        {

            try
            {
                return _users;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<ToDo> GetUserToDos(Guid userId)
        {

            try
            {
                return _repository.GetToDos(userId);

            }
            catch (Exception)
            {

                throw;
            }
        }





        public UserDTO GetById(string id)
        {
            try
            {
                var user = _repository.GetUserById(id);
                return new UserDTO()
                {
                    Username = user.UserName,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Id = user.Id.ToString()
                };
            }
            catch (Exception)
            {

                throw;
            }
        }

        // helper methods

        private string generateJwtToken(UserDTO user)
        {
            // generate token that is valid for 7 days - not really ideal, but just for the purpose of demo
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public ToDo AddToDo(ToDoDTO todo)
        {
            try
            {
                return _repository.AddTodo(todo);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public ToDo EditTodo(ToDoDTO todo)
        {
            try
            {
                return _repository.editTodo(todo);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool deleteToDo(ToDoDTO todDo)
        {
            try
            {
                return _repository.deleteToDo(todDo);
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}

