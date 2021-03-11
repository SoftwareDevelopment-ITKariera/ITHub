using ITHub.Data;
using ITHub.Data.Models;
using ITHub.Services.Contracts;
using System;

namespace ITHub.Services
{
    public class CategoriesService : ICategoriesService
    {
        private ITHubDBContext context;

        public CategoriesService(ITHubDBContext context)
        {
            this.context = context;
        }

        public int CreateCategory(string name)
        {
            var category = new Category() { Name = name };
            context.Categories.Add(category);
            context.SaveChanges();
            return category.Id;
        }
    }
}
