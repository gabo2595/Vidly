using System.Collections.Generic;
using Domain.Entities;

namespace Models.Out
{
    public class CategoryBasicInfoModel
    {
        List<Movie> movies = new List<Movie>();
        public CategoryBasicInfoModel(Category category) {
            this.Id = category.Id;
            this.Name = category.Name;
        }

        public int Id { get; set; }
        public string Name { get; set; }
    }
}