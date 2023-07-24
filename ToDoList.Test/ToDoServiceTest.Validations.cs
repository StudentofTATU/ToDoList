using FluentAssertions;
using ToDoList.Contracts.Items;
using ToDoList.Models.Exceptions;
using ToDoList.Models.Items;
using Xunit;

namespace ToDoList.Test
{
    public partial class ToDoServiceTest
    {
        [Fact]
        public async Task InputValidateItem()
        {
            //given
            string invalidId = "";
            var expectedInvalidInputException = new ItemNotFoundException(invalidId);

            //when
            ValueTask<bool> deleteItem = toDoService.DeleteItem(invalidId);

            InvalidInputException actualInvalidInputException =
                await Assert.ThrowsAsync<InvalidInputException>(deleteItem.AsTask);

            //then
            actualInvalidInputException.Should().BeEquivalentTo(expectedInvalidInputException);

        }

        [Fact]
        public async Task CreateItemWithWrongToDoId()
        {
            //given
            CreateItemDTO invalidItem = new CreateItemDTO
            {
                Title = "Home tasks",
                Description = "Clean bathroom",
                ToDoId = Guid.NewGuid(),
                CreatedDate = DateTime.Now,
                DueDate = DateTime.Today,
            };

            var expectedToDoNotFoundException = 
                new ToDoNotFoundException(invalidItem.ToDoId.ToString());

            //when
            ValueTask<bool> deleteItem =  toDoService.CreateToDoItem(invalidItem);

            ToDoNotFoundException actualToDoNotFoundException =
                await Assert.ThrowsAsync<ToDoNotFoundException>(deleteItem.AsTask);

            //then
            actualToDoNotFoundException.Should().BeEquivalentTo(expectedToDoNotFoundException);

        }
    }
}
