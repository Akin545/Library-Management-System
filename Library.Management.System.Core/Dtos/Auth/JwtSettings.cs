using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Management.System.Core.Dtos.Auth
{
    public class JwtSettings
    {
        public string Key { get; set; } = "MySuperGeneralFotTestPurposeStrongSecretKey_12345678901234567890";
        public int ExpiresMinutes { get; set; } = 60;
        public string? Issuer { get; set; } = "LibraryManagementSystem";
        public string? Audience { get; set; } = "LibraryManagementSystem";
    }
}
