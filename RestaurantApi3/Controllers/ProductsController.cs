using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace RestaurantApi3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        [Route("all")]
        public ActionResult<List<Product>> Get()
        {
            var result = _productService.GetAll();
            if (result.IsSuccess) return Ok(result);
            return BadRequest(result);
        }

        [HttpGet]
        public ActionResult<Product> Get(int id)
        {
            var result = _productService.Get(id);
            if (result.IsSuccess) return Ok(result);
            return BadRequest(result);
        }

        [HttpGet]
        [Route("category")]
        public ActionResult<Product> GetByCategoryId(int categoryId)
        {
            var result = _productService.ByCategoryId(categoryId);
            if (result.IsSuccess) return Ok(result);
            return BadRequest(result);
        }

        [HttpGet]
        [Route("details")]
        public ActionResult<Product> GetDetails(int id)
        {
            var result = _productService.GetProductDetails(id);
            if (result.IsSuccess) return Ok(result);
            return BadRequest(result);
        }

        [HttpPost]
        [Route("add")]
        public ActionResult Add(Product product)
        {
            var result = _productService.Add(product);
            if (result.IsSuccess) return Ok(result);
            return BadRequest(result);
        }

        [HttpDelete]
        [Route("delete")]
        public ActionResult Delete(int id)
        {
            var result = _productService.Delete(id);
            if (result.IsSuccess) return Ok(result);
            return BadRequest(result);
        }

        [HttpPost]
        [Route("updateproductstock")]
        public ActionResult UpdateStock(Product product, short newProductStock)
        {
            product.UnitsInStock = newProductStock;
            var result = _productService.Update(product);
            if (result.IsSuccess) return Ok(result);
            return BadRequest(result);
        }
    }
}