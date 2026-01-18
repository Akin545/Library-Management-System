using Library.Management.System.Core.Interface;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Management.System.Core.Dtos
{
    public class SearchResponseDTO<T> where T : IDto
    {
        public List<T> Results { get; set; } = null!;
        public int? MaxLength { get; set; }
    }
}
