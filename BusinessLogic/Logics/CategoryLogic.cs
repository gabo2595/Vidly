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

        public Category Add(Category category)
        {
            if(category == null)
            {
                throw new ArgumentNullException(nameof(category));
            }

            this.categoriesRepository.Add(category);
            this.categoriesRepository.SaveChanges();

            return category;
        }

        public void Delete(int id)
        {
            var category = this.GetById(id);

            if(category == null)
            {
                throw new ArgumentException("Category doesn't exist", "Id:" + id);
            }

            this.categoriesRepository.Delete(category);
            this.categoriesRepository.SaveChanges();
        }

        public IEnumerable<Category> GetAll()
        {
            return this.categoriesRepository.GetAll();
        }

        public Category GetById(int id)
        {
            var category = this.categoriesRepository.GetById(id);

            if(category == null)
            {
                throw new ArgumentException(nameof(category), "Category doesn't exist");
            }

            return category;
        }

        public void Update(int id, Category category)
        {
            if(category == null)
            {
                throw new ArgumentNullException(nameof(category));
            }

            if(!this.categoriesRepository.Exists(id))
            {
                throw new ArgumentException("Category doesn't exist", "Id:" + id);
            }

            var categoryToUpdate = this.GetById(id);

            this.categoriesRepository.Update(categoryToUpdate);
            this.categoriesRepository.SaveChanges();
        }
  }
}