using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IntroAsp.Models
{
    public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre del libro es obligatorio.")]
        [StringLength(150)]
        public string BookName { get; set; } = string.Empty;

        [Required(ErrorMessage = "La editorial es obligatoria.")]
        [StringLength(150)]
        public string Editorial { get; set; } = string.Empty;

        [Required(ErrorMessage = "Debe seleccionar un autor.")]
        [Display(Name = "Autor")]
        public int AuthorId { get; set; }

        [ForeignKey("AuthorId")]
        public Author? Author { get; set; }
    }
}