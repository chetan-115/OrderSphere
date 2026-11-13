using organization.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace organization.Domain.Entities
{
    public class Organization
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public OrganizationType OrganizationType { get; set; }
        public string LegalName { get; set; } = string.Empty;
        public string? TaxRegistrationNumber { get; set; }
        public string Email { get; set; } = string.Empty;
        public string? Phone { get; set; }
        public string? Website { get; set; }
        public OrganizationStatus OrganizationStatus { get; set; }
        public DateTimeOffset CreatedAtUtc { get; set; }
        public DateTimeOffset? UpdatedAtUtc { get; set; }
    }
}
