using Library.Management.System.Core.Enum;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Management.System.Core.Dtos.User
{
    public class UserDto : Dto
    {
        public string Email { get; set; } = string.Empty;

        public string? PhoneNumber { get; set; }

        public string FullName { get; set; } = string.Empty;

        public RoleTypeEnum Roles { get; set; } = RoleTypeEnum.User;

    }
}