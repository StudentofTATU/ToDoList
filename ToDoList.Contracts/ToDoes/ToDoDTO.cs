using ToDoList.Models.ToDoes;

namespace ToDoList.Contracts.ToDoes
{
    public class ToDoDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ToDoState Visibility { get; set; }
        public ToDoDTO(ToDo toDo) 
        {
            this.Id = toDo.Id;
            this.Name = toDo.Name;
            this.Visibility = toDo.Visibility;
        }
    }
}
