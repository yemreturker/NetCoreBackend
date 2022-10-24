using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace RestaurantApi3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        ICategoryService _categoryService;
        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        [Route("all")]
        public ActionResult<List<Category>> Get()
        {
            var result = _categoryService.GetAll();
            if (result.IsSuccess) return Ok(result);
            return BadRequest(result);
        }

        [HttpGet]
        public ActionResult<Category> GetById(int id)
        {
            var result = _categoryService.GetById(id);
            if (result.IsSuccess) return Ok(result);
            return BadRequest(result);
        }

        [HttpPost]
        [Route("add")]
        public ActionResult add(Category category)
        {
            var result = _categoryService.Add(category);
            if (result.IsSuccess) return Ok(result);
            return BadRequest(result);
        }

        [HttpDelete]
        [Route("delete")]
        public ActionResult delete(int id)
        {
            var result = _categoryService.Delete(id);
            if (result.IsSuccess) return Ok(result);
            return BadRequest(result);
        }
    }
}
