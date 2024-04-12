﻿namespace MovieLibraryAPI.Models.DTO
{
    public class StreamingServiceCreateDTO
    {
        public Guid Id { get; set; }
        public string ServiceName { get; set; }
        public string Type { get; set; }
        public string Link { get; set; }
        public string? Price { get; set; }
        public Guid Fk_MovieId { get; set; }
    }
}
