﻿using ToDiList.Domain.Model.Base;
using ToDiList.Domain.Model.System;

namespace ToDiList.Domain.Model.Security
{
    public class ApplicationUser : BaseModel<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string NormalizeUserName { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }
        public string NormalizeEmail { get; set; }
        public bool ConfirmedEmail { get; set; } = false;
        public string? PhoneNumber { get; set; }
        public bool? ConfirmedPhoneNumber { get; set; }
        public bool NeedUpdate { get; set; } = false;
        public DateTime? LastUpdatedDate { get; set; }

        public virtual ICollection<Section>? Section { get; set; }
    }
}