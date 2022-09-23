using Library.Core.Base;
using System.ComponentModel.DataAnnotations;

namespace Library.Core.Entities
{
    public class Message : EntityBase
    {
        public Member? Member { get; set; }
        [Required]
        public int MemberId { get; set; }
        [Required]
        public string? MessageContext { get; set; }
        [Required]
        public string? MessageSubject { get; set; }
        [Required]
        public DateTime SendData { get; set; }

    }
}
