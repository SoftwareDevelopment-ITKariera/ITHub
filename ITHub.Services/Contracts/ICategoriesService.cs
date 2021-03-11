using System;
using System.Collections.Generic;
using System.Text;

namespace ITHub.Services.Contracts
{
    public interface ICategoriesService
    {
        int CreateCategory(string name);
    }
}
