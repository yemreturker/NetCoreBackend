using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace RestaurantApi3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TableItemsController : ControllerBase
    {
        ITableItemService _tableItemService;

        public TableItemsController(ITableItemService tableItemService)
        {
            _tableItemService = tableItemService;
        }

        [HttpGet]
        [Route("all")]
        public ActionResult GetAll()
        {
            var result = _tableItemService.GetAll();
            if (result.IsSuccess) return Ok(result);
            return BadRequest(result);
        }

        [HttpGet]
        public ActionResult GetByTableId(int tableId)
        {
            var result = _tableItemService.GetByTableId(tableId);
            if (result.IsSuccess) return Ok(result);
            return BadRequest(result);
        }

        [HttpGet]
        [Route("details")]
        public ActionResult GetDetails(int id)
        {
            var result = _tableItemService.GetDetails(id);
            if (result.IsSuccess) return Ok(result);
            return BadRequest(result);
        }

        [HttpPost]
        [Route("add")]
        public ActionResult Add(TableItem tableItem)
        {
            var result = _tableItemService.Add(tableItem);
            if (result.IsSuccess) return Ok(result);
            return BadRequest(result);
        }

        [HttpPost]
        [Route("update")]
        public ActionResult Update(TableItem tableItem)
        {
            var result = _tableItemService.Update(tableItem);
            if (result.IsSuccess) return Ok(result);
            return BadRequest(result);
        }

        [HttpDelete]
        [Route("delete")]
        public ActionResult Delete(int id)
        {
            var result = _tableItemService.Delete(id);
            if (result.IsSuccess) return Ok(result);
            return BadRequest(result);
        }
    }
}