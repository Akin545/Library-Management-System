using Library.Management.System.Core.Enum;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Management.System.Core.Models
{
    public class User : Entity
    {
        [Required, MaxLength(100)]
        public string FullName { get; set; } = string.Empty;

        [Required, MaxLength(100), EmailAddress]
        public string Email { get; set; } = string.Empty;
        public RoleTypeEnum Roles { get; set; } = RoleTypeEnum.User;

        [MaxLength(20)]
        public string? PhoneNumber { get; set; }
        public string PasswordHash { get; set; } = string.Empty;

      
    }
}
