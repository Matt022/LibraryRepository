using Library.Core.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Entities
{
    public class QueueItem : EntityBase
    {
        public Member? Member { get; set; }
        [Required]
        public int MemberId { get; set; }

        [Required]
        public DateTime TimeAdded { get; set; }
        public Title? Title { get; set; }
        [Required]
        public int TitleId { get; set; }
        [Required]
        public bool IsResolved { get; set; }

        public override string ToString()
        {
            return $"Title: {Title.Name} - Member: {Member.FirstName} {Member.LastName} - IsResolved: {this.IsResolved}";
        }

    }
}
