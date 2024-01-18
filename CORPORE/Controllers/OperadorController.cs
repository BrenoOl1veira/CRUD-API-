using Microsoft.AspNetCore.Mvc;
using API.Models;
using API.Services.OperadorService;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    /// <summary>
    /// Controlador responsável pelas operações relacionadas aos operadores.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class OperadorController : ControllerBase
    {
        private readonly IOperadorInterface _operadorService;

        /// <summary>
        /// Construtor que recebe uma instância da interface de serviço de operadores.
        /// </summary>
        /// <param name="operadorService">Instância da interface de serviço de operadores.</param>
        public OperadorController(IOperadorInterface operadorService)
        {
            _operadorService = operadorService;
        }

        /// <summary>
        /// Obtém todos os operadores.
        /// </summary>
        /// <returns>Resposta do serviço contendo a lista de operadores ou mensagem de erro.</returns>
        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<OperadorModel>>>> GetOperadores()
        {
            ServiceResponse<List<OperadorModel>> serviceResponse = await _operadorService.GetOperadores();
            if (!serviceResponse.Sucesso)
            {
                return StatusCode(500, new { Error = serviceResponse.Mensagem });
            }

            return Ok(serviceResponse);
        }

        /// <summary>
        /// Obtém um operador pelo seu identificador.
        /// </summary>
        /// <param name="id">Identificador do operador.</param>
        /// <returns>Resposta do serviço contendo o operador encontrado ou mensagem de erro.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<OperadorModel>>> GetOperadorById(int id)
        {
            ServiceResponse<OperadorModel> serviceResponse = await _operadorService.GetOperadorById(id);
            if (!serviceResponse.Sucesso)
            {
                return StatusCode(500, new { Error = serviceResponse.Mensagem });
            }

            return Ok(serviceResponse);
        }

        /// <summary>
        /// Cria um novo operador.
        /// </summary>
        /// <param name="novoOperador">Dados do novo operador a ser criado.</param>
        /// <returns>Resposta do serviço contendo a lista de operadores atualizada ou mensagem de erro.</returns>
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<OperadorModel>>>> CreateOperador(OperadorModel novoOperador)
        {
            ServiceResponse<List<OperadorModel>> serviceResponse = await _operadorService.CreateOperador(novoOperador);
            if (!serviceResponse.Sucesso)
            {
                return StatusCode(500, new { Error = serviceResponse.Mensagem });
            }

            return Ok(serviceResponse);
        }

        /// <summary>
        /// Atualiza um operador existente.
        /// </summary>
        /// <param name="id">Identificador do operador a ser atualizado.</param>
        /// <param name="editadoOperador">Dados do operador atualizado.</param>
        /// <returns>Resposta do serviço contendo a lista de operadores atualizada ou mensagem de erro.</returns>
        [HttpPut("{id}")]
        public async Task<ActionResult<ServiceResponse<List<OperadorModel>>>> UpdateOperador(int id, OperadorModel editadoOperador)
        {
            ServiceResponse<List<OperadorModel>> serviceResponse = await _operadorService.UpdateOperador(id, editadoOperador);
            if (!serviceResponse.Sucesso)
            {
                return StatusCode(500, new { Error = serviceResponse.Mensagem });
            }

            return Ok(serviceResponse);
        }

        /// <summary>
        /// Exclui um operador existente.
        /// </summary>
        /// <param name="id">Identificador do operador a ser excluído.</param>
        /// <returns>Resposta do serviço contendo a lista de operadores atualizada ou mensagem de erro.</returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<List<OperadorModel>>>> DeleteOperador(int id)
        {
            ServiceResponse<List<OperadorModel>> serviceResponse = await _operadorService.DeleteOperador(id);
            if (!serviceResponse.Sucesso)
            {
                return StatusCode(500, new { Error = serviceResponse.Mensagem });
            }

            return Ok(serviceResponse);
        }
    }
}
