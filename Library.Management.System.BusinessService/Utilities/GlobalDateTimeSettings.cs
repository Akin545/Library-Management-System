using Library.Management.System.BusinessService.Interfaces.Utilities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Management.System.BusinessService.Utilities
{
    public class GlobalDateTimeSettings : IGlobalDateTimeSettings
    {
        public DateTime CurrentDateTime { get => DateTime.UtcNow; }
    }
}