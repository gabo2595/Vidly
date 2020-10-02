using System.Collections.Generic;
using System.Linq;
using DataAccessInterface.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DbSet<Category> categories;
        private readonly DbContext vidlyContext;

        public CategoryRepository(DbContext context)
        {
            this.vidlyContext = context;
            this.categories = context.Set<Category>();
        }

        public void Add(Category category)
        {
            this.categories.Add(category);
        }

        public void Delete(Category category)
        {
            this.categories.Remove(category);
        }

        public bool Exists(int id)
        {
            return this.categories.Any(c => c.Id == id);
        }

        public IEnumerable<Category> GetAll()
        {
            return this.categories.ToList();
        }

        public Category GetById(int id)
        {
            return this.categories.FirstOrDefault(c => c.Id == id);
        }

        public void SaveChanges()
        {
            this.vidlyContext.SaveChanges();
        }

        public void Update(Category category)
        {
            this.vidlyContext.Entry(category).State = EntityState.Modified;
        }
  }
}