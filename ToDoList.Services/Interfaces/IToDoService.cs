using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Contracts.Items;
using ToDoList.Contracts.ToDoes;

namespace ToDoList.Services.Interfaces
{
    public interface IToDoService
    {
        bool CreateToDo(CreateToDoDTO createToDoDTO);
        ValueTask<bool> CreateToDoItem(CreateItemDTO createItemDTO);
        Task<ToDoDTO> GetToDoAsyncById(string toDoId);
        Task<IEnumerable<ToDoDTO>> GetAllToDoesAsync();
        Task<IEnumerable<ItemDTO>> GetAllItemsAsync(string toDoId);
        ValueTask<bool> DeleteItem(string itemId);
    }
}
