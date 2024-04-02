using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MovieLibraryAPI.Models.DTO
{
    public class MovieDTO
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Runtime { get; set; }
        public string Genre { get; set; }
        public string Director { get; set; }
        public string Writer { get; set; }
        public string Actors { get; set; }
        public string Plot { get; set; }
        public string Year { get; set; }
        public string Awards { get; set; }
        public string Poster { get; set; }
        public string Fk_UserId { get; set; }
        public virtual ApplicationUserDTO User { get; set; }
        public virtual ICollection<RatingDTO> Ratings { get; set; }
        public virtual ICollection<StreamingServiceDTO> StreamingServices { get; set; }
    }
}
