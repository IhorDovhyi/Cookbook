using System.Collections.Generic;
using Cookbook.Controllers.UseCases;
using Cookbook.Models;
using Cookbook.Patterns.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace Cookbook.Controllers
{
    [ApiController]
    [Route("api/recipes")]
    public class RecipeController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        public RecipeController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IEnumerable<Recipe> GetAll()
        {
            return new GetUseCase(this.unitOfWork).Execute();
        }
        [HttpGet("{id}")]
        public Recipe Get(int id)
        {
            Recipe recipe = new GetUseCase(this.unitOfWork).Execute(id);
            this.unitOfWork.Save();
            return recipe;
        }

        [HttpPost]
        public IActionResult Post(Recipe recipe)
        {
            if (ModelState.IsValid)
            {
                return Ok(new PostUseCase(this.unitOfWork).Execute(recipe));
            }
            return BadRequest(ModelState);
        }

        [HttpPut]
        public IActionResult Put(Recipe recipe)
        {
            if (ModelState.IsValid)
            {
                return Ok(new PutUseCase(this.unitOfWork).Execute(recipe));
            }
            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
           if (new DeleteUseCase(this.unitOfWork).Execute(id))
            {
 
                return Ok(ModelState);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}