using System.ComponentModel.DataAnnotations;

namespace GraphQl.DataBase.Models
{
    public class DbBaseModel
    {
        [Required]
        public DateTimeOffset CreatedOn { get; set; }
        public DateTimeOffset? LastUpdateTime { get; set; }
    }
}