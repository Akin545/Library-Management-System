using Library.Management.System.Core.Interface;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Management.System.Core.Dtos.Book
{
    public class SearchBookDTO : IDtoNoID
    {
        public string? Title { get; set; }

        public string? Author { get; set; }

        public int? CurrentPageNumber { get; set; }
    }
}
