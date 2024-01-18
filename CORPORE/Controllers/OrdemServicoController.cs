using Microsoft.AspNetCore.Mvc;
using API.Models;
using API.Services.OrdemServicoService;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace API.Controllers
{
    /// <summary>
    /// Controlador responsável pelas operações relacionadas às ordens de serviço.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class OrdemServicoController : ControllerBase
    {
        private readonly IOrdemServicoInterface _ordemServicoService;

        /// <summary>
        /// Construtor que recebe uma instância da interface de serviço de ordens de serviço.
        /// </summary>
        /// <param name="ordemServicoService">Instância da interface de serviço de ordens de serviço.</param>
        public OrdemServicoController(IOrdemServicoInterface ordemServicoService)
        {
            _ordemServicoService = ordemServicoService;
        }

        /// <summary>
        /// Obtém todas as ordens de serviço.
        /// </summary>
        /// <returns>Resposta do serviço contendo a lista de ordens de serviço ou mensagem de erro.</returns>
        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<OrdemServicoModel>>>> GetOrdensServico()
        {
            ServiceResponse<List<OrdemServicoModel>> serviceResponse = await _ordemServicoService.GetOrdensServico();
            if (!serviceResponse.Sucesso)
            {
                return StatusCode(500, new { Error = serviceResponse.Mensagem });
            }

            return Ok(serviceResponse);
        }

        /// <summary>
        /// Obtém uma ordem de serviço pelo seu identificador.
        /// </summary>
        /// <param name="id">Identificador da ordem de serviço.</param>
        /// <returns>Resposta do serviço contendo a ordem de serviço encontrada ou mensagem de erro.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<OrdemServicoModel>>> GetOrdemServicoById(int id)
        {
            ServiceResponse<OrdemServicoModel> serviceResponse = await _ordemServicoService.GetOrdemServicoById(id);
            if (!serviceResponse.Sucesso)
            {
                return NotFound(new { Error = serviceResponse.Mensagem });
            }

            return Ok(serviceResponse);
        }

        /// <summary>
        /// Cria uma nova ordem de serviço.
        /// </summary>
        /// <param name="novaOrdemServico">Dados da nova ordem de serviço a ser criada.</param>
        /// <returns>Resposta do serviço contendo a lista de ordens de serviço atualizada ou mensagem de erro.</returns>
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<OrdemServicoModel>>>> CreateOrdemServico(OrdemServicoModel novaOrdemServico)
        {
            ServiceResponse<List<OrdemServicoModel>> serviceResponse = await _ordemServicoService.CreateOrdemServico(novaOrdemServico);
            if (!serviceResponse.Sucesso)
            {
                return BadRequest(new { Error = serviceResponse.Mensagem });
            }

            return Ok(serviceResponse);
        }

        /// <summary>
        /// Atualiza uma ordem de serviço existente.
        /// </summary>
        /// <param name="id">Identificador da ordem de serviço a ser atualizada.</param>
        /// <param name="editadaOrdemServico">Dados da ordem de serviço atualizada.</param>
        /// <returns>Resposta do serviço contendo a lista de ordens de serviço atualizada ou mensagem de erro.</returns>
        [HttpPut("{id}")]
        public async Task<ActionResult<ServiceResponse<List<OrdemServicoModel>>>> UpdateOrdemServico(int id, OrdemServicoModel editadaOrdemServico)
        {
            ServiceResponse<List<OrdemServicoModel>> serviceResponse = await _ordemServicoService.UpdateOrdemServico(id, editadaOrdemServico);
            if (!serviceResponse.Sucesso)
            {
                return BadRequest(new { Error = serviceResponse.Mensagem });
            }

            return Ok(serviceResponse);
        }

        /// <summary>
        /// Exclui uma ordem de serviço existente.
        /// </summary>
        /// <param name="id">Identificador da ordem de serviço a ser excluída.</param>
        /// <returns>Resposta do serviço contendo a lista de ordens de serviço atualizada ou mensagem de erro.</returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<List<OrdemServicoModel>>>> DeleteOrdemServico(int id)
        {
            ServiceResponse<List<OrdemServicoModel>> serviceResponse = await _ordemServicoService.DeleteOrdemServico(id);
            if (!serviceResponse.Sucesso)
            {
                return NotFound(new { Error = serviceResponse.Mensagem });
            }

            return Ok(serviceResponse);
        }
    }
}
