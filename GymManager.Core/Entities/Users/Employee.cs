using GymManager.Core.Enums;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace GymManager.Core.Entities
{
    public class Employee : IdentityUser
    {
        [Required]
        public EmployeeType EpmployeeType { get; set; }
    }
}
