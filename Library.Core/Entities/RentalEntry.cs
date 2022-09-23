using Library.Core.Base;
using Library.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace Library.Core.Entities
{
    public class RentalEntry : EntityBase
    {
        public Member? Member { get; set; }

        [Required]
        public int MemberId { get; set; }

        [Required]
        public DateTime RentedDate { get; set; }

        public DateTime? ReturnDate { get; set; }

        public Title? Title { get; set; }
        [Required]
        public int TitleId { get; set; }

        public int TimesProlongued { get; set; }
        public bool IsReturned => this.ReturnDate is not null;

        public eTitleType TitleType { get; set; }

        public override string ToString()
        {
            return $"{Title.Name} - {Title.Author} - Rented on: {RentedDate.ToShortDateString()} - Rented by: {Member.FirstName} {Member.LastName} - Returned: {(!IsReturned ? "NOT RETURNED" : ReturnDate.Value.ToShortDateString())} - Times prolongued: {TimesProlongued}";
        }
    }
}
