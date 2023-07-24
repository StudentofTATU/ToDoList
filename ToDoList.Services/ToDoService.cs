using Microsoft.IdentityModel.Tokens;
using ToDoList.Contracts.Items;
using ToDoList.Contracts.ToDoes;
using ToDoList.Data.Interfaces;
using ToDoList.Models.Exceptions;
using ToDoList.Models.Items;
using ToDoList.Models.ToDoes;
using ToDoList.Services.Interfaces;

namespace ToDoList.Services
{
    public class ToDoService:IToDoService
    {
        private readonly IToDoRepository toDoRepository;
        private readonly IItemRepository itemRepository;

        public ToDoService(IToDoRepository toDoRepository, IItemRepository itemRepository)
        {
            this.toDoRepository = toDoRepository;
            this.itemRepository = itemRepository;
        }

        public bool CreateToDo(CreateToDoDTO createToDoDTO)
        {
            ToDo toDo = new ToDo
            {
                Id= Guid.NewGuid(),
                Name= createToDoDTO.Name,
                Visibility=ToDoState.VISIABLE
            };

            return toDoRepository.Add(toDo);
        }
        public async ValueTask<bool> CreateToDoItem(CreateItemDTO createItemDTO)
        {
            Item item=new Item { 
                Id= Guid.NewGuid(),
                Title=createItemDTO.Title,
                Description=createItemDTO.Description,
                ToDoId= createItemDTO.ToDoId,
                CreatedDate= DateTime.Now,
                DueDate= createItemDTO.DueDate
            };

            if (item.ToDoId.ToString().IsNullOrEmpty()) 
                throw new InvalidInputException(item.ToDoId.ToString());
            ToDo toDo = await toDoRepository.GetToDoByIdAsync(item.ToDoId.ToString());

            if (toDo == null) throw new ToDoNotFoundException(item.ToDoId.ToString());

            return itemRepository.Add(item);
        }

        public async Task<ToDoDTO> GetToDoAsyncById(string toDoId)
        {
            if (toDoId.IsNullOrEmpty()) throw new InvalidInputException(toDoId);

            ToDo toDo =await toDoRepository.GetToDoByIdAsync(toDoId);

            if(toDo == null) throw new ToDoNotFoundException(toDoId);

            ToDoDTO toDoDTO = new ToDoDTO(toDo);
            
            return toDoDTO;
        }

        public async Task<IEnumerable<ToDoDTO>> GetAllToDoesAsync()
        {
            IEnumerable<ToDo> toDoList= await toDoRepository.GetAllToDoes();

            List<ToDoDTO> toDoDTOList = new List<ToDoDTO>();
            
            foreach (var toDo in toDoList)
            {
                toDoDTOList.Add(new ToDoDTO(toDo));
            }

            return toDoDTOList;
        }

        public async Task<IEnumerable<ItemDTO>> GetAllItemsAsync(string toDoId)
        {
            if (toDoId.IsNullOrEmpty()) throw new InvalidInputException(toDoId);

            IEnumerable<Item> itemList = itemRepository.GetAllItemsByToDos(toDoId);

            List<ItemDTO> itemDTOList = new List<ItemDTO>();

            foreach (var item in itemList)
            {
                itemDTOList.Add(new ItemDTO(item));
            }

            return itemDTOList;
        }

        public async ValueTask<bool> DeleteItem(string itemId)
        {
            if (itemId.IsNullOrEmpty()) throw new InvalidInputException(itemId);
            
            return await itemRepository.Delete(itemId);
        }
    }
}
