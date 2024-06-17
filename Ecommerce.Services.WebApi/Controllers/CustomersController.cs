using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ecommerce.Application.DTO;
using Ecommerce.Application.Interface;
using Microsoft.AspNetCore.Authorization;

namespace Ecommerce.Services.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomersApplication _customerApplication;
        public CustomersController(ICustomersApplication customerApplication)
        {
            _customerApplication = customerApplication;
        }
        #region Metodos Sincronos
        [HttpPost("Insert")]
        public IActionResult Insert([FromBody]CustomersDto customersDto)
        {
            if(customersDto == null)
                return BadRequest();
            var response = _customerApplication.Insert(customersDto);
            if (response.IsSucces) return Ok(response);
            return BadRequest(response.Message);
        }
        [HttpPut("Update")]
        public IActionResult Update([FromBody] CustomersDto customersDto)
        {
            if (customersDto == null)
                return BadRequest();
            var response = _customerApplication.Update(customersDto);
            if (response.IsSucces) return Ok(response);
            return BadRequest(response.Message);
        }
        [HttpDelete("Delete/{customersId}")]
        public IActionResult Delete(string customersId)
        {
            if (string.IsNullOrEmpty(customersId))
                return BadRequest();
            var response = _customerApplication.Delete(customersId);
            if (response.IsSucces) return Ok(response);
            return BadRequest(response.Message);
        }
        [HttpGet("Get/{customersId}")]
        public IActionResult Get(string customersId)
        {
            if (string.IsNullOrEmpty(customersId))
                return BadRequest();
            var response = _customerApplication.Get(customersId);
            if (response.IsSucces) return Ok(response);
            return BadRequest(response.Message);
        }
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var response = _customerApplication.GetAll();
            if (response.IsSucces) return Ok(response);
            return BadRequest(response.Message);
        }
        #endregion
        #region Metodos Asincronos
        [HttpPost("InsertAsync")]
        public async Task<IActionResult> InsertAsync([FromBody] CustomersDto customersDto)
        {
            if (customersDto == null)
                return BadRequest();
            var response = await _customerApplication.InsertAsync(customersDto);
            if (response.IsSucces) return Ok(response);
            return BadRequest(response.Message);
        }
        [HttpPut("UpdateAsync")]
        public async Task<IActionResult> UpdateAsync([FromBody] CustomersDto customersDto)
        {
            if (customersDto == null)
                return BadRequest();
            var response = await _customerApplication.UpdateAsync(customersDto);
            if (response.IsSucces) return Ok(response);
            return BadRequest(response.Message);
        }
        [HttpDelete("DeleteAsync/{customersId}")]
        public async Task<IActionResult> DeleteAsync(string customersId)
        {
            if (string.IsNullOrEmpty(customersId))
                return BadRequest();
            var response = await _customerApplication.DeleteAsync(customersId);
            if (response.IsSucces) return Ok(response);
            return BadRequest(response.Message);
        }
        [HttpGet("GetAsync/{customersId}")]
        public async Task<IActionResult> GetAsync(string customersId)
        {
            if (string.IsNullOrEmpty(customersId))
                return BadRequest();
            var response = await _customerApplication.GetAsync(customersId);
            if (response.IsSucces) return Ok(response);
            return BadRequest(response.Message);
        }
        [HttpGet("GetAllAsync")]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = await _customerApplication.GetAllAsync();
            if (response.IsSucces) return Ok(response);
            return BadRequest(response.Message);
        }
        #endregion
    }
}
