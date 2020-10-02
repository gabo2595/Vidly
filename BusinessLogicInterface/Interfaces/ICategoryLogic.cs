using System.Collections.Generic;
using Domain.Entities;

namespace BusinessLogicInterface.Interfaces
{
    public interface ICategoryLogic
    {
        IEnumerable<Category> GetAll();
        Category GetById(int id);
        Category Add(Category category);
        void Update(int id, Category category);
        void Delete(int id);
    }
}