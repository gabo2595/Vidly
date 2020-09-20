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

        public void Create(Category category)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(Category category)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Category> GetAll()
        {
            return this.categories.ToList();
        }

        public Category GetById(int id)
        {
            return this.categories.FirstOrDefault(c => c.Id == id);
        }

        public void Update(Category category)
        {
            throw new System.NotImplementedException();
        }
  }
}