using System;
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
        public IActionResult Get()
        {
            try
            {
                var categories = this.categoriesLogic.GetAll();
                return Ok(categories.Select(c => new CategoryBasicInfoModel(c)).ToList());
            }
            catch(ArgumentNullException)
            {
                return BadRequest();
            }            
        }

        // GET: api/categories/{id}
        [HttpGet("{id}", Name = "GetCategory")]
        public IActionResult Get([FromRoute]int id)
        {
            try
            {
                var category = this.categoriesLogic.GetById(id);
                return Ok(new CategoryDetailInfoModel(category));
            }
            catch(ArgumentException)
            {
                return NotFound();
            }
        }

        // POST: api/categories
        [HttpPost]
        public IActionResult Post([FromBody]CategoryModel categoryModel)
        {
            try
            {
                var cateogry = this.categoriesLogic.Add(categoryModel.ToEntity());
                return CreatedAtRoute("GetCategory", new {id = cateogry.Id },
                    new CategoryDetailInfoModel(cateogry));
            }
            catch(ArgumentNullException)
            {
                return BadRequest();
            }

        }

        // PUT: api/categories/{id}
        [HttpPut("{id}")]
        public ActionResult Put([FromRoute]int id, [FromBody]CategoryModel category)
        {
            this.categoriesLogic.Update(id, category.ToEntity());
            return NoContent();
        }

        //DELETE api/categories/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteCommand(int id)
        {
            this.categoriesLogic.Delete(id);
            return NoContent();
        }
    }
}