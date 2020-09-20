using System.Collections.Generic;
using System.Linq;
using BusinessLogicInterface.Interfaces;
using DataAccessInterface.Interfaces;
using Domain.Entities;

namespace BusinessLogic.Logics
{
    public class CategoryLogic : ICategoryLogic
    {
        private readonly ICategoryRepository categoriesRepository;

        public CategoryLogic(ICategoryRepository categoriesRepository)
        {
            this.categoriesRepository = categoriesRepository;
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
            return this.categoriesRepository.GetAll();
        }

        public Category GetById(int id)
        {
            return this.categoriesRepository.GetById(id);
        }

        public void Update(Category category)
        {
            throw new System.NotImplementedException();
        }
  }
}