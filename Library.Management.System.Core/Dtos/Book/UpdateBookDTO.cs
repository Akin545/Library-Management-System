using Library.Management.System.Core.Interface;

using System.ComponentModel.DataAnnotations;

namespace Library.Management.System.Core.Dtos.Book
{
    public class UpdateBookDTO: IDtoNoID
    {
        [MaxLength(60)]
        public string? ISBN { get; set; }

        [MaxLength(200)]
        public string? Title { get; set; }

        [MaxLength(200)]
        public string? Author { get; set; }

        public DateTime? PublishedDate { get; set; }
    }
}
