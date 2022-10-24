using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace RestaurantApi3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderFichesController : ControllerBase
    {
        IOrderFicheService _orderFicheService;

        public OrderFichesController(IOrderFicheService orderFicheService)
        {
            _orderFicheService = orderFicheService;
        }

        [HttpGet]
        [Route("all")]
        public ActionResult GetAll()
        {
            var result = _orderFicheService.GetAll();
            if (result.IsSuccess) return Ok(result);
            return BadRequest(result);
        }

        [HttpGet]
        public ActionResult Get(int id)
        {
            var result = _orderFicheService.Get(id);
            if (result.IsSuccess) return Ok(result);
            return BadRequest(result);
        }

        [HttpGet]
        [Route("details")]
        public ActionResult GetDetails(int id)
        {
            var result = _orderFicheService.GetOrderFicheDetails(id);
            if (result.IsSuccess) return Ok(result);
            return BadRequest(result);
        }

        [HttpPost]
        [Route("add")]
        public ActionResult Add(OrderFiche orderFiche)
        {
            var result = _orderFicheService.Add(orderFiche);
            if (result.IsSuccess) return Ok(result);
            return BadRequest(result);
        }

        [HttpDelete]
        [Route("delete")]
        public ActionResult Remove(int id)
        {
            var result = _orderFicheService.Delete(id);
            if (result.IsSuccess) return Ok(result);
            return BadRequest(result);
        }
    }
}