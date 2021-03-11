using System;
using System.Collections.Generic;
using System.Text;

namespace ITHub.View.Models
{
    public class IndexAllSongsViewModel
    {
        public IEnumerable<IndexSingleSongModel> Songs { get; set; }
    }
}
