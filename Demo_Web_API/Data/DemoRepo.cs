using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Demo_Web_API.DBModels;
using Demo_Web_API.Models;
using Demo_Web_API.Entities;

namespace Demo_Web_API.Data
{
    public class DemoRepo : IDemoRepo
    {
        private readonly techTest_dbContext  _context = new techTest_dbContext();

        public ToDo AddTodo(ToDoDTO toDoObj)
        {
            try
            {
                ToDo toDo = new ToDo()
                {
                    ToDoText = toDoObj.text,
                    UserId = Guid.Parse(toDoObj.userId),
                    Id = Guid.NewGuid(),
                };
                _context.ToDos.Add(toDo);
                _context.SaveChanges();
                return toDo;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public ToDo editTodo(ToDoDTO toDoObj)
        {
            try
            {
               
               var toDoToBeUpdated= _context.ToDos.FirstOrDefault(todo=>todo.Id== Guid.Parse(toDoObj.Id));
                toDoToBeUpdated.ToDoText = toDoObj.text;
                _context.SaveChanges();
                return toDoToBeUpdated;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<ToDo> GetToDos(Guid userId)
        {

            try
            {
                return _context.ToDos.Where(toDo => toDo.UserId == userId).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public User GetUser(AuthenticateRequest authRequest)
        {

            try
            {
                return _context.Users.Where(user=>user.Password== authRequest.Password && user.UserName== authRequest.Username).SingleOrDefault();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public User GetUserById(string userId)
        {

            try
            {
                Guid userID = Guid.Parse(userId);

                return _context.Users.Where(user => user.Id== userID).SingleOrDefault();
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
                ToDo toDoToBeDeleted = new ToDo()
                {
                    Id = Guid.Parse(todDo.Id)
                };
                _context.Remove(toDoToBeDeleted);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                throw;
            }

        }



    }
}
