using System;
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
            if(category == null)
            {
                throw new ArgumentNullException(nameof(category));
            }

            this.categoriesRepository.Create(category);
        }

        public void Delete(Category category)
        {
            this.categoriesRepository.Delete(category);
        }

        public bool Exists(int id)
        {
            return this.categoriesRepository.Exists(id);
        }

        public IEnumerable<Category> GetAll()
        {
            return this.categoriesRepository.GetAll();
        }

        public Category GetById(int id)
        {
            return this.categoriesRepository.GetById(id);
        }

        public bool SaveChanges()
        {
            return this.categoriesRepository.SaveChanges();
        }

        public void Update(Category category)
        {
            if(category == null)
            {
                throw new ArgumentNullException(nameof(category));
            }

            this.categoriesRepository.Update(category);
        }
  }
}