using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace MovieLibraryAPI.Models.DTO
{
    public class RatingUpdateDTO
    {
        public Guid Id { get; set; }
        public string Source { get; set; }
        public string Value { get; set; }
        public Guid Fk_MovieId { get; set; }
    }
}
