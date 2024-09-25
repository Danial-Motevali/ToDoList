namespace ToDoList.Application.Settings
{
    public class IdentitySetting
    {
        public string SigningKey { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string Subject { get; set; }
    }
}
