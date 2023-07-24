namespace ToDoList.Models.Exceptions
{
    public class ItemNotFoundException : NotFoundException
    {
        public ItemNotFoundException(string itemId)
             : base($"This {itemId} item id is not found.")
        {

        }
    }
}
