using System.Collections.Generic;
using System.Linq;
using BusinessLogicInterface.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Model.In;
using Model.Out;

namespace WebApi.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryLogic categoriesLogic;

        public CategoryController(ICategoryLogic categoriesLogic)
        {
            this.categoriesLogic = categoriesLogic;
        }

        // GET: api/categories
        [HttpGet]
        public ActionResult<IEnumerable<CategoryBasicInfoModel>> GetAllCategories()
        {
            var categories = categoriesLogic.GetAll();
            
            return Ok(categories.Select(m => new CategoryBasicInfoModel(m)).ToList());
        }

        // GET: api/categories/{id}
        [HttpGet("{id}")]
        public ActionResult<CategoryDetailInfoModel> GetCategory(int id)
        {
            var category = categoriesLogic.GetById(id);

            if (category == null)
            {
                return NotFound();
            }

            return Ok(new CategoryDetailInfoModel(category));
        }

        // POST: api/categories
        [HttpPost]
        public ActionResult<CategoryModel> CreateCategory(Category category)
        {
            this.categoriesLogic.Create(category);
            this.categoriesLogic.SaveChanges();

            var newCategory = new CategoryModel(category);

            return CreatedAtAction("GetCategory", new { id = newCategory.Id }, newCategory);
        }

        // PUT: api/categories/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateCategory(int id, Category category)
        {
            if (id != category.Id)
            {
                return BadRequest();
            }

            if (!CategoryExists(id))
            {
                return NotFound();
            }

            this.categoriesLogic.Update(category);
            this.categoriesLogic.SaveChanges();

            return NoContent();
        }

        //DELETE api/categories/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteCommand(int id)
        {
            var category = this.categoriesLogic.GetById(id);

            if(category == null)
            {
                return NotFound();
            }

            this.categoriesLogic.Delete(category);
            this.categoriesLogic.SaveChanges();

            return NoContent();
        }

        private bool CategoryExists(int id)
        {
            return categoriesLogic.Exists(id);
        }
    }
}