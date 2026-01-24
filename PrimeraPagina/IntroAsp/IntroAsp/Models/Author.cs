using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IntroAsp.Models
{
    public class Author
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AuthorId { get; set; }
        [Required(ErrorMessage = "El nombre del autor es obligatorio.")]
        [StringLength(100)]
        public string AuthorName { get; set; } = string.Empty;

        public virtual ICollection<Book> Books { get; set; } = new HashSet<Book>();

    }
}
