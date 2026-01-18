using Library.Management.System.Core.Interface;

using System.ComponentModel.DataAnnotations;

namespace Library.Management.System.Core.Dtos.Book
{
    public class CreateBookDTO: IDtoNoID
    {
        [MaxLength(60)]
        public string? ISBN { get; set; }

        [Required, MaxLength(200)]
        public string Title { get; set; }

        [Required, MaxLength(100)]
        public string Author { get; set; }

        [Required]
        public DateTime PublishedDate { get; set; }
    }
}
