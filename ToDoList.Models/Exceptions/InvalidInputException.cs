namespace ToDoList.Models.Exceptions
{
    public class InvalidInputException : NotFoundException
    {
        public InvalidInputException(string input)
             : base($"This {input} input value is not valid.")
        {

        }
    }
}
