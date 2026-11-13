using System;
using System.Collections.Generic;
using System.Text;

namespace organization.Domain.Entities
{
    public class OrganizationContact
    {
        public Guid Id { get; set; }
        public Guid OrganizationId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string? PhoneNumber { get; set; }
        public string Email { get; set; } = string.Empty;
        public string? Designation { get; set; }
        public bool IsPrimary { get; set; } = false;

    }
}
