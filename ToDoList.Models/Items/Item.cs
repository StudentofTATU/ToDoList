using ToDoList.Models.ToDoes;

namespace ToDoList.Models.Items
{
    public class Item
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid ToDoId { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset DueDate { get; set; }
    }
}
