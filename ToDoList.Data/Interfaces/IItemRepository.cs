using ToDoList.Models.Items;
using ToDoList.Models.ToDoes;

namespace ToDoList.Data.Interfaces
{
    public interface IItemRepository
    {
        IEnumerable<Item> GetAllItemsByToDos(string toDoId);
        Task<Item> GetItemByIdAsync(string itemId);
        bool Add(Item item);
        bool Update(Item item);
        Task<bool> Delete(string itemId);
        bool SaveChanges();
    }
}
