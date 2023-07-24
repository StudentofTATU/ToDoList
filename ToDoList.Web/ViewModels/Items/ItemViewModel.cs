namespace ToDoList.Web.ViewModels.Items
{
    public class ItemViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid ToDoId { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset DueDate { get; set; }
    }
}
