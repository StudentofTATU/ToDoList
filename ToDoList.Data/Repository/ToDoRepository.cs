using Microsoft.EntityFrameworkCore;
using ToDoList.Data.Interfaces;
using ToDoList.Models.ToDoes;

namespace ToDoList.Data.Repository
{
    public class ToDoRepository : IToDoRepository
    {
        private readonly AppDbContext context;

        public ToDoRepository(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<ToDo>> GetAllToDoes()
        {
            return await context.ToDoes.ToListAsync();
        }

        public async Task<ToDo> GetToDoByIdAsync(string toDoId)
        {
            return await context.ToDoes.FindAsync(Guid.Parse(toDoId));
        }

        public bool Add(ToDo toDo)
        {
            context.ToDoes.Add(toDo);

            return SaveChanges();
        }

        public bool Delete(string toDoId)
        {
            throw new NotImplementedException();
        }

        public bool SaveChanges()
        {
            var saved = context.SaveChanges();

            return saved > 0;
        }

        public bool Update(ToDo toDo)
        {
            throw new NotImplementedException();
        }
    }
}
