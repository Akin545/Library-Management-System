using Library.Management.System.Core.Interface;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Management.System.Core.Dtos
{
    public class DtoIdentity : IDtoIdentity
    {
        public int Id { get; set; }
    }
}