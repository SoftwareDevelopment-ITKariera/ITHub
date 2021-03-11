using System;
using System.Collections.Generic;
using System.Text;

namespace ITHub.Services.Contracts
{
    public interface ISongsService
    {
        int CreateSong(string name, string description, string link, string category); 
    }
}
