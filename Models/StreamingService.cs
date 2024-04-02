﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MovieLibraryAPI.Models
{
    public class StreamingService
    {
        public Guid Id { get; set; }
        [StringLength(50)]
        public string ServiceName { get; set; }
        [StringLength(25)]
        public string Type { get; set; }
        public string Link { get; set; }
        [StringLength(25)]
        public string? Price { get; set; }
        [ForeignKey("Movie")]
        public Guid Fk_MovieId { get; set; }
        public virtual Movie Movie { get; set; }
    }
}
