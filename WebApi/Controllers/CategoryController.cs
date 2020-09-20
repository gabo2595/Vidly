using System.Collections.Generic;
using System.Linq;
using BusinessLogicInterface.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models.Out;

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
    }
}