namespace Domain.Entities
{
    public class CategoryMovie
    {
        public int Id { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public int MovieId { get; set; }
        public virtual Movie Movie { get; set; }
    }
}