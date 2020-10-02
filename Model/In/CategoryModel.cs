using Domain.Entities;

namespace Model.In
{
    public class CategoryModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Category ToEntity()
        {
            return new Category()
            {
                Name = this.Name,
            };
        }
    }
}