using ToDoList.Models.ToDoes;

namespace ToDoList.Data.Interfaces
{
    public interface IToDoRepository
    {
        Task<IEnumerable<ToDo>> GetAllToDoes(); 
        Task<ToDo> GetToDoByIdAsync(string toDoId);
        bool Add(ToDo toDo);
        bool Update(ToDo toDo);
        bool Delete(string toDoId);
        bool SaveChanges();
    }
}
