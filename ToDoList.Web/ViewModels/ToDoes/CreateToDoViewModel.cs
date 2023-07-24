using System.ComponentModel.DataAnnotations;
using ToDoList.Contracts.ToDoes;

namespace ToDoList.Web.ViewModels.ToDoes
{
    public class CreateToDoViewModel
    {
        [Required]
        public string Name { get; set; }
        public CreateToDoDTO CreateToDoDTO()
        {
            return new CreateToDoDTO
            {
                Name = this.Name,
            };
        }
    }
}
