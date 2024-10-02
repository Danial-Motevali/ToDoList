using Microsoft.Extensions.Options;
using System.Security.Cryptography;
using ToDoList.Application.Contract.Utilities.IdentityLayer;
using ToDoList.Application.Settings;

namespace ToDoList.Identity.Utilities
{
    public class HashPasswordHelperUtiltiy : IHashPasswordHelperUtiltiy
    {
        private readonly HashingSetting _hashingSetting;
        public HashPasswordHelperUtiltiy(IOptions<HashingSetting> hashingSetting)
        {
            _hashingSetting = hashingSetting.Value;
        }

        public  string ConverToHash(string password)
        {
            using (var algorithm = new Rfc2898DeriveBytes(password, _hashingSetting.SaltSize, _hashingSetting.Iterations, HashAlgorithmName.SHA256))
            {
                var key = Convert.ToBase64String(algorithm.GetBytes(_hashingSetting.KeySize));
                var salt = Convert.ToBase64String(algorithm.Salt);

                return $"{_hashingSetting.Iterations}.{salt}.{key}";
            }
        }

        public bool ValidateTheHash(string password, string hash) 
        {
            var parts = hash.Split('.', 3);

            if (parts.Length != 3)
            {
                return false;
            }

            var iterations = Convert.ToInt32(parts[0]);
            var salt = Convert.FromBase64String(parts[1]);
            var key = Convert.FromBase64String(parts[2]);

            using (var algorithm = new Rfc2898DeriveBytes(password, salt, iterations, HashAlgorithmName.SHA256))
            {
                var keyToCheck = algorithm.GetBytes(_hashingSetting.KeySize);

                var verified = keyToCheck.SequenceEqual(key);

                return verified;
            }
        }
    }
}
