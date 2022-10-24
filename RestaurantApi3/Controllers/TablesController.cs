using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace RestaurantApi3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TablesController : ControllerBase
    {
        ITableService _tableService;
        public TablesController(ITableService tableService)
        {
            _tableService = tableService;
        }

        [HttpGet]
        [Route("all")]
        public ActionResult<List<Table>> Get()
        {
            var result = _tableService.GetAll();
            if (result.IsSuccess) return Ok(result);
            return BadRequest(result);
        }

        [HttpGet]
        public ActionResult<Table> Get(int id)
        {
            var result = _tableService.Get(id);
            if (result.IsSuccess) return Ok(result);
            return BadRequest(result);
        }

        [HttpPost]
        [Route("add")]
        public ActionResult Add(Table table)
        {
            var result = _tableService.Add(table);
            if (result.IsSuccess) return Ok(result);
            return BadRequest(result);
        }

        [HttpPost]
        [Route("update")]
        public ActionResult Update(Table table)
        {
            var result = _tableService.Update(table);
            if (result.IsSuccess) return Ok(result);
            return BadRequest(result);
        }

        [HttpDelete]
        [Route("delete")]
        public ActionResult Delete(int id)
        {
            var result = _tableService.Delete(id);
            if (result.IsSuccess) return Ok(result);
            return BadRequest(result);
        }
    }
}
