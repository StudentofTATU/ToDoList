
namespace ToDoList.Models.ToDoes
{
    public class ToDo
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ToDoState Visibility { get; set; }
    }
}
