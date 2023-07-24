namespace ToDoList.Models.Exceptions
{
    public class ToDoNotFoundException : NotFoundException
    {
        public ToDoNotFoundException(string itemId)
             : base($"This {itemId} todo id is not found.")
        {

        }
    }
}
