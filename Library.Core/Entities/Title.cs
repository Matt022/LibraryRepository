using Library.Core.Base;
using System.ComponentModel.DataAnnotations;

namespace Library.Core.Entities
{
    public abstract class Title : EntityBase
    {
        [Required]
        public string Author { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int AvailableCopies { get; set; }
        [Required]
        public int TotalAvailableCopies { get; set; }
    }
}
