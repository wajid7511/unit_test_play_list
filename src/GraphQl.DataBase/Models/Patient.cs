using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GraphQl.DataBase.Models
{
    public class Patient : DbBaseModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(
            50,
            MinimumLength = 3,
            ErrorMessage = "Name should be between 3-50 characters"
        )]
        public string Name { get; set; } = string.Empty;
    }
}