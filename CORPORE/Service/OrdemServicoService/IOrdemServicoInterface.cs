using API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Services.OrdemServicoService
{
    // Interface para operações relacionadas a ordens de serviço
    public interface IOrdemServicoInterface
    {
        // Obtém a lista de ordens de serviço
        Task<ServiceResponse<List<OrdemServicoModel>>> GetOrdensServico();

        // Obtém uma ordem de serviço pelo ID
        Task<ServiceResponse<OrdemServicoModel>> GetOrdemServicoById(int id);

        // Cria uma nova ordem de serviço
        Task<ServiceResponse<List<OrdemServicoModel>>> CreateOrdemServico(OrdemServicoModel novaOrdemServico);

        // Atualiza uma ordem de serviço pelo ID
        Task<ServiceResponse<List<OrdemServicoModel>>> UpdateOrdemServico(int id, OrdemServicoModel editadaOrdemServico);

        // Exclui uma ordem de serviço pelo ID
        Task<ServiceResponse<List<OrdemServicoModel>>> DeleteOrdemServico(int id);
    }
}
