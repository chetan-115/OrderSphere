using organization.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace organization.Domain.Entities
{
    public class OrganizationAddress
    {
        public Guid Id { get; set; }
        public Guid OrganizationId { get; set; }
        public string AddressLine1 { get; set; } = string.Empty;
        public string? AddressLine2 { get; set; }
        public string City { get; set; } = string.Empty;
        public string? State { get; set; }
        public string PostalCode { get; set; } = string.Empty;
        public string CountryCode { get; set; } = string.Empty;
        public AddressType AddressType { get; set; }
        public bool IsPrimary { get; set; } = false;

    }
}
