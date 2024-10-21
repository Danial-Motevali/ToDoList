namespace TaskManager.Application.Utilities
{
    public static class PasswordHasherHelper
    {
        public static string CreateHash(string password)
        {
            if (password == null)
                return null;

            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public static bool ValidHash(string inputPassword, string userPassword)
        {
            if(inputPassword == null || userPassword == null)
                return false;

            return BCrypt.Net.BCrypt.Verify(inputPassword, userPassword);
        }
    }
}
