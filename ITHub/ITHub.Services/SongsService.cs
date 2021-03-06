using ITHub.Data;
using ITHub.Data.Models;
using ITHub.Services.Contracts;
using ITHub.View.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ITHub.Services
{
    public class SongsService : ISongsService
    {
        private ITHubDBContext context;

        public SongsService(ITHubDBContext context)
        {
            this.context = context;
        }
        public int CreateSong(string name,string description,string link,string category)
        {
            var categoryObj = this.context.Categories.FirstOrDefault(x => x.Name == category);
            var song = new Song()
            {
                Name = name,
                Description = description,
                Link = link,
                CategoryId = categoryObj.Id,
                Views = 1
            };

            this.context.Songs.Add(song);
            categoryObj.Songs.Add(song);
            this.context.SaveChanges();

            return song.Id;
        }

        public IndexAllSongsViewModel GetAllSongs()
        {
            var songs = context.Songs.Where(x=>x.DeletedOn==null).Select(s => new IndexSingleSongModel()
            {
                Name = s.Name,
                Link = s.Link,
                Description = s.Description,
                Category = s.Category.Name,
                Id = s.Id
            });

            var model = new IndexAllSongsViewModel()
            { Songs = songs};
            return model;

        }
    }
}
