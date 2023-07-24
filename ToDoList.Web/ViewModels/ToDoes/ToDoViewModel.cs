using System.ComponentModel.DataAnnotations;
using ToDoList.Contracts.Items;
using ToDoList.Contracts.ToDoes;
using ToDoList.Models.ToDoes;
using ToDoList.Web.ViewModels.Items;

namespace ToDoList.Web.ViewModels.ToDoes
{
    public class ToDoViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ToDoState Visibility { get; set; }
        public IEnumerable<ItemViewModel> Items { get; set; }
    }
}
