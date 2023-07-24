
namespace ToDoList.Contracts.Items
{
    public class CreateItemDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid ToDoId { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset DueDate { get; set; }
    }
}
