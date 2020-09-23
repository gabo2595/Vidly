using Domain.Entities;

namespace Model.In
{
    public class CategoryModel
    {
        public CategoryModel(Category movie) {
            this.Id = movie.Id;
            this.Name = movie.Name;
        }

        public int Id { get; set; }
        public string Name { get; set; }
    }
}