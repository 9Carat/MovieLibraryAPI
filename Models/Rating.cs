using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace MovieLibraryAPI.Models
{
    public class Rating
    {
        public Guid Id { get; set; }
        [StringLength(50)]
        [DisplayName("Reviewer")]
        public string Source { get; set; }
        [StringLength(10)]
        [DisplayName("Score")]
        public string Value { get; set; }
        [ForeignKey("Movie")]
        public Guid Fk_MovieId { get; set; }
        public virtual Movie Movie { get; set; }
    }
}
