using System;
using System.Collections.Generic;
using System.Text;

namespace ITHub.Data.Models
{
    public class Song
    {
        public Song()
        {
            this.UploadDate = DateTime.UtcNow;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
        public DateTime UploadDate { get; set; }
        public DateTime? DeletedOn { get; set; }
        public long Views { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int? PlaylistId { get; set; }
        public Playlist Playlist { get; set; }
    }
}
