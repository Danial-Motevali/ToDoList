using ToDiList.Domain.Model.Base;
using ToDiList.Domain.Model.System;

namespace ToDiList.Domain.Model.Security
{
    public class ApplicationUser : BaseModel<Guid>
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string UserName { get; private set; }
        public string NormalizeUserName { get; private set; }
        public string PasswordHash { get; private set; }
        public string Email { get; private set; }
        public string NormalizeEmail { get; private set; }
        public bool ConfirmedEmail { get; private set; }
        public string? PhoneNumber { get; private set; }
        public bool? ConfirmedPhoneNumber { get; private set; }
        public bool NeedUpdate { get; private set; }
        public DateTime? LastUpdatedDate { get; private set; }

        public virtual ICollection<Section>? Section { get; private set; }


        public ApplicationUser
            (
                string FirstName,
                string LastName,
                string UserName,
                string PasswordHash,
                string Email,
                bool? ConfirmedEmail,
                string? PhoneNumber,
                bool? ConfirmedPhoneNumber,
                bool? NeedUpdate,
                DateTime? LastUpdatedDate
            )
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.UserName = UserName;
            this.NormalizeUserName = UserName.ToUpper();
            this.PasswordHash = PasswordHash;
            this.Email = Email;
            this.NormalizeEmail = Email.ToUpper();
            this.ConfirmedEmail = ConfirmedEmail != null ? (bool)ConfirmedEmail : false;
            this.PhoneNumber = PhoneNumber;
            this.ConfirmedEmail = ConfirmedEmail != null ? (bool)ConfirmedEmail : false;
            this.NeedUpdate = NeedUpdate != null ? (bool)NeedUpdate : false;
            this.LastUpdatedDate = LastUpdatedDate != null ? (DateTime)LastUpdatedDate : (DateTime?)null;
        }
    }
}
