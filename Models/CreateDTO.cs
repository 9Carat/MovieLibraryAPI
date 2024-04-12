using MovieLibraryAPI.Models.DTO;

namespace MovieLibraryAPI.Models
{
    public class CreateDTO
    {
        public MovieCreateDTO movieDTO { get; set; }
        public List<RatingCreateDTO> ratingDTO { get; set; }
        public List<StreamingServiceCreateDTO> streamingServiceDTO { get; set; }
    }
}
