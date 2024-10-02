namespace ToDoList.Application.Contract.Utilities.IdentityLayer
{
    public interface IHashPasswordHelperUtiltiy
    {
        public string ConverToHash(string password);
        public bool ValidateTheHash(string password, string hash);
    }
}
