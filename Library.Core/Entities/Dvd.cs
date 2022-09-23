

using System.ComponentModel.DataAnnotations;

namespace Library.Core.Entities
{
    public class Dvd : Title
    {
        [Required]
        public int NumberOfChapters { get; set; }
        [Required]
        public int NumberOfMinutes { get; set; }


        public override string ToString()
        {
            return $"Name: {this.Name} - Author: {this.Author} - Number of chapters: {this.NumberOfChapters} - Length in minutes: {this.NumberOfMinutes} - Available copies: {this.AvailableCopies}";
        }

    }
}
