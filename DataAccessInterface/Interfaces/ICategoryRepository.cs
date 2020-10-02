using System.Collections.Generic;
using Domain.Entities;

namespace DataAccessInterface.Interfaces
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetAll();
        Category GetById(int id);
        void Add(Category category);
        void Update(Category category);
        void Delete(Category category);
        bool Exists(int id);
        void SaveChanges();
    }
}