using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Management.System.Core.Exceptions
{
    public class BookException : PermissionBaseException
    {
        public BookException(string message) : base(message)
        {

        }
    }
}
