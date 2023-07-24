using ToDoList.Models.Items;

namespace ToDoList.Contracts.Items
{
    public  class ItemDTO
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid ToDoId { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset DueDate { get; set; }

        public ItemDTO(Item item) 
        { 
            Id=item.Id;
            Title=item.Title;
            Description=item.Description;
            ToDoId=item.ToDoId;
            CreatedDate = item.CreatedDate;
            DueDate = item.DueDate;
        }
    }
}
