using System.Collections.Generic;
using System.Linq;
using Domain.Entities;

namespace Models.Out
{
    public class CategoryDetailInfoModel
    {
        public CategoryDetailInfoModel(Category category) {
            this.Id = category.Id;
            this.Name = category.Name;
            this.Movies = category.Movies.Select(m => new MovieBasicInfoModel(m)).ToList();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public List<MovieBasicInfoModel> Movies { get; set; }
    }
}