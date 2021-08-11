using Demo_Web_API.Entities;
using Demo_Web_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Demo_Web_API.DBModels;

namespace Demo_Web_API.Services
{
    public interface IUserService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model);
        IEnumerable<UserDTO> GetAll();
        UserDTO GetById(string id);
        IEnumerable<ToDo> GetUserToDos(Guid userId);

        ToDo AddToDo(ToDoDTO todo);
        ToDo EditTodo(ToDoDTO todo);


        bool deleteToDo(ToDoDTO todDo);



    }
}
