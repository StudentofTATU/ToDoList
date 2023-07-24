using Moq;
using ToDoList.Services;

namespace ToDoList.Test
{
    public partial class ToDoServiceTest
    {
        private readonly Mock<ToDoService> toDoServiceMock;
        private readonly ToDoService toDoService;

        public ToDoServiceTest()
        {
            this.toDoServiceMock= new Mock<ToDoService>();
            this.toDoService = toDoServiceMock.Object;
        }
    }
}
