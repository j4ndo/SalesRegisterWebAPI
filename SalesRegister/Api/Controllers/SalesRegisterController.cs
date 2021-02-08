using Microsoft.AspNetCore.Mvc;
using SalesRegisterWebAPI.Application;
using SalesRegisterWebAPI.Domain.DTO;
using SalesRegisterWebAPI.Domain.Validators;
using SalesRegisterWebAPI.Domain.ViewModel;
using System;
using System.Threading.Tasks;

namespace SalesRegisterWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SalesRegisterController : ControllerBase
    {
        private ISalesRegisterApplication _application;

        public SalesRegisterController(ISalesRegisterApplication application)
        {
            _application = application;
        }

        [HttpPost]
        public async Task<ActionResult<SalesRegisterDTO>> CreateSalesRegister(SalesRegisterDTO salesRegisterDTO)
        {
            
            var validator = new SalesRegisterValidator();
            var validation = validator.Validate(salesRegisterDTO);

            if (validation.IsValid)
            {
                var salesRegister = await _application.CreateSalesRegisterAsync(salesRegisterDTO);
            
                return CreatedAtAction(
                        nameof(GetSalesRegisterById),
                        new { idSalesRegister = salesRegister.IdSalesRegister},
                        salesRegister);
            }
            else
            {
                return BadRequest(validation.Errors);
            }

        }

        [HttpGet("{idSalesRegister}")]
        public async Task<ActionResult<SalesRegisterDTO>> GetSalesRegisterById(long idSalesRegister)
        {
            var result = await _application.GetSalesRegisterByIdAsync(idSalesRegister);

            if (result != null)
                return Ok(result);
            else
                return NotFound("Registro de venda não localizado.");            
        }

        [HttpPut("{idSalesRegister}")]
        public async Task<IActionResult> UpdateSalesRegister(long idSalesRegister, SalesRegisterPutDTO salesRegisterPutDTO)
        {
            if (idSalesRegister != salesRegisterPutDTO.IdSalesRegister)
            {
                return BadRequest("Identificador informado é inválido.");
            }

            var isValidSalesRegisterStatus = await _application.ValidateStatusChangeSalesRegister(salesRegisterPutDTO.Status, salesRegisterPutDTO.IdSalesRegister);

            if (!isValidSalesRegisterStatus)
            {
                return BadRequest("Status informado é invalido.");
            }

            var salesRegister = await _application.UpdateSalesRegisterAsync(salesRegisterPutDTO);

            if (salesRegister != null)
                return Ok(salesRegister);
            else
                return NotFound("Registro de venda não localizado.");
        }


    }
}
