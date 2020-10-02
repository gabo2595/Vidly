using System.Collections.Generic;
using System.Linq;
using Domain.Entities;
using Model.Out;

namespace Model.In
{
    public class MovieModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int AgeAllowed { get; set; }
        public IEnumerable<int> Categories { get; set; }

        public Movie ToEntity()
        {
            return new Movie()
            {
                Name = this.Name,
                Description = this.Description,
                AgeAllowed = this.AgeAllowed,
                CategoriesMovies = this.Categories.Select(c => new CategoryMovie()
                {
                    CategoryId = c
                }).ToList()
            };
        }
    }
}