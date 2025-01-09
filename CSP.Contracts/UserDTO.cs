using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSP.Contracts
{
    // DTO for Creating or Updating a User
    public class UserDto
    {
        public Guid? UserId { get; set; } // Optional for Create operations
        public string Name { get; set; } // User's full name
        public string Email { get; set; } // User's email address
        public string Phone { get; set; } // User's phone number
        public Guid CityId { get; set; } // Foreign key referencing the City
        public Guid TenantId { get; set; } // Foreign key referencing the Tenant
        public bool IsActive { get; set; } // Flag indicating if the user is active
    }

    // DTO for Returning User Details
    public class UserResponseDto
    {
        public Guid UserId { get; set; } // Unique identifier for the user
        public string Name { get; set; } // User's full name
        public string Email { get; set; } // User's email address
        public string Phone { get; set; } // User's phone number
        public string CityName { get; set; } // Name of the city the user belongs to
        public Guid TenantId { get; set; } // Tenant ID to which the user belongs
        public bool IsActive { get; set; } // Active status of the user
    }
}
