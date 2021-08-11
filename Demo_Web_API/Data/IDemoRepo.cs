using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Demo_Web_API.DBModels;
using Demo_Web_API.Models;
using Demo_Web_API.Entities;

namespace Demo_Web_API.Data
{
    public interface IDemoRepo
    {
        IEnumerable<ToDo> GetToDos(Guid userId);

        ToDo AddTodo(ToDoDTO toDoObj);
        User GetUser(AuthenticateRequest authRequest);
        User GetUserById(string userId);
        bool deleteToDo(ToDoDTO todDo);
        ToDo editTodo(ToDoDTO toDoObj);




    }
}
