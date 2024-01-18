using API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Services.OperadorService
{
    // Interface para operações relacionadas a operadores
    public interface IOperadorInterface
    {
        // Obtém a lista de operadores
        Task<ServiceResponse<List<OperadorModel>>> GetOperadores();

        // Obtém um operador pelo ID
        Task<ServiceResponse<OperadorModel>> GetOperadorById(int id);

        // Cria um novo operador
        Task<ServiceResponse<List<OperadorModel>>> CreateOperador(OperadorModel novoOperador);

        // Atualiza um operador pelo ID
        Task<ServiceResponse<List<OperadorModel>>> UpdateOperador(int id, OperadorModel editadoOperador);

        // Exclui um operador pelo ID
        Task<ServiceResponse<List<OperadorModel>>> DeleteOperador(int id);

        // Inativa um operador pelo ID
        Task<ServiceResponse<List<OperadorModel>>> InativarOperador(int id);
    }
}
