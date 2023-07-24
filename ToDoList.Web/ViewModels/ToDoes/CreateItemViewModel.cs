using ToDoList.Contracts.Items;

namespace ToDoList.Web.ViewModels.ToDoes
{
    public class CreateItemViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid ToDoId { get; set; }
        public DateTimeOffset DueDate { get; set; }
        public CreateItemDTO CreateItemDTO()
        {
            return new CreateItemDTO
            {
                ToDoId= this.ToDoId,
                Title= this.Title,
                Description= this.Description,
                DueDate= this.DueDate
            };
        }
    }
}
