using Microsoft.EntityFrameworkCore;
using ToDoList.Data.Interfaces;
using ToDoList.Models.Items;
using ToDoList.Models.Exceptions;

namespace ToDoList.Data.Repository
{
    public class ItemRepository : IItemRepository
    {
        private readonly AppDbContext context;

        public ItemRepository(AppDbContext context)
        {
            this.context = context;
        }
        public IEnumerable<Item> GetAllItemsByToDos(string toDoId)
        {
            return context.Items.Where(i => toDoId.Equals(i.ToDoId.ToString())).ToList();
        }

        public async Task<Item> GetItemByIdAsync(string itemId)
        {
            return await context.Items.FirstOrDefaultAsync(i => i.Id.Equals(itemId));
        }

        public bool Add(Item item)
        {
            context.Items.Add(item);

            return SaveChanges();
        }

        public async Task<bool> Delete(string itemId)
        {
            Item deleteItem = context.Items.Find(itemId);

            if (deleteItem == null) throw new ItemNotFoundException(itemId);
            context.Items.Remove(deleteItem);
            
            return  SaveChanges();
        }



        public bool SaveChanges()
        {
            var saved = context.SaveChanges();

            return saved > 0;
        }

        public bool Update(Item item)
        {
            throw new NotImplementedException();
        }
    }
}
