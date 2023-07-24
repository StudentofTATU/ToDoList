using Microsoft.AspNetCore.Mvc;
using ToDoList.Contracts.Items;
using ToDoList.Contracts.ToDoes;
using ToDoList.Data.Repository;
using ToDoList.Models.ToDoes;
using ToDoList.Services.Interfaces;
using ToDoList.Web.ViewModels.Items;
using ToDoList.Web.ViewModels.ToDoes;

namespace ToDoList.Web.Controllers
{
    public class ToDoController : Controller
    {
        private readonly IToDoService toDoService;

        public ToDoController(IToDoService toDoService)
        {
            this.toDoService = toDoService;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<ToDoDTO> toDoes = await toDoService.GetAllToDoesAsync();
            IEnumerable<ToDoViewModel> toDoViewModels = toDoes.Select(i=>new ToDoViewModel()
            {
                Id=i.Id,
                Name=i.Name,
                Visibility=i.Visibility
            });
            return View(toDoViewModels);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpGet("[action]/{id}")]
        public IActionResult AddItem(string id)
        {
            ViewBag.Id=id;
            return View();
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> ToDoDetail(string id)
        {
            ToDoDTO toDoDTO =await toDoService.GetToDoAsyncById(id);
            //shu yerda item list ol todonikini
            IEnumerable<ItemDTO> items= await toDoService.GetAllItemsAsync(toDoDTO.Id.ToString());
            IEnumerable<ItemViewModel> itemsViewModel = items.Select(i => new ItemViewModel
            {
                Id=i.Id,
                Title=i.Title,
                Description=i.Description,
                ToDoId=i.ToDoId,
                CreatedDate=i.CreatedDate,
                DueDate=i.DueDate
                
            });
            ToDoViewModel toDoViewModel = new ToDoViewModel()
            {
                Id = toDoDTO.Id,
                Name = toDoDTO.Name,
                Visibility = toDoDTO.Visibility,
                Items=itemsViewModel
            };

            return View(toDoViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateToDoViewModel toDoVM)
        {
            if (ModelState.IsValid)
            {
                toDoService.CreateToDo(toDoVM.CreateToDoDTO());

                return RedirectToAction("Index", "ToDo");
            }

            return View(toDoVM);
        }

        [HttpPost]
        public async Task<IActionResult> NewItem(CreateItemViewModel toDoVM)
        {
            if (ModelState.IsValid)
            {

                toDoService.CreateToDoItem(toDoVM.CreateItemDTO());

                return RedirectToAction("Index", "ToDo");
            }

            return View(toDoVM);
        }
    }
}
