using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace RestaurantApi3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        IPaymentService _paymentService;

        public PaymentsController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpGet]
        [Route("getall")]
        public ActionResult GetAll()
        {
            var result = _paymentService.GetAll();
            if (result.IsSuccess) return Ok(result);
            return BadRequest(result);
        }

        [HttpGet]
        public ActionResult Get(int id)
        {
            var result = _paymentService.Get(id);
            if (result.IsSuccess) return Ok(result);
            return BadRequest(result);
        }

        [HttpGet]
        [Route("getdetails")]
        public ActionResult GetDetails(int id)
        {
            var result = _paymentService.GetPaymentDetails(id);
            if (result.IsSuccess) return Ok(result);
            return BadRequest(result);
        }

        [HttpPost]
        [Route("add")]
        public ActionResult Add(Payment payment)
        {
            var result = _paymentService.Add(payment);
            if (result.IsSuccess) return Ok(result);
            return BadRequest(result);
        }

        [HttpDelete]
        [Route("delete")]
        public ActionResult Remove(int id)
        {
            var result = _paymentService.Delete(id);
            if (result.IsSuccess) return Ok(result);
            return BadRequest(result);
        }

        [HttpGet]
        [Route("getbyorderficheid")]
        public ActionResult GetByOrderFicheId(int orderFicheId)
        {
            var result = _paymentService.GetPaymentByOrderFicheId(orderFicheId);
            if (result.IsSuccess) return Ok(result);
            return BadRequest(result);
        }
    }
}