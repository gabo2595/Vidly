using System.Collections.Generic;
using Domain.Entities;

namespace DataAccessInterface.Interfaces
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetAll();
        Category GetById(int id);
        void Create(Category category);
        void Update(Category category);
        void Delete(Category category);
        bool Exists(int id);
        bool SaveChanges();
    }
}