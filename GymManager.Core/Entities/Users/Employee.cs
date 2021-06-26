using GymManager.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace GymManager.Core.Entities
{
    public class Employee : User
    {
        [Required]
        public EmployeeType EpmployeeType { get; set; }
    }
}
