using API.Data;
using API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Services.OrdemServicoService
{
    // Implementação da interface IOrdemServicoInterface para operações relacionadas a ordens de serviço
    public class OrdemServicoService : IOrdemServicoInterface
    {
        // Contexto do banco de dados
        private readonly ApplicationDbContext _context;

        // Construtor que recebe o contexto do banco de dados
        public OrdemServicoService(ApplicationDbContext context)
        {
            _context = context;
        }

        // Obtém a lista de todas as ordens de serviço
        public async Task<ServiceResponse<List<OrdemServicoModel>>> GetOrdensServico()
        {
            // Resposta do serviço
            ServiceResponse<List<OrdemServicoModel>> serviceResponse = new();

            try
            {
                // Obtém todas as ordens de serviço do banco de dados, incluindo dados do operador associado
                serviceResponse.Dados = await _context.OrdensServico.Include(os => os.Operador).ToListAsync();

                // Se a lista estiver vazia, configura a mensagem correspondente
                if (serviceResponse.Dados.Count == 0)
                {
                    serviceResponse.Mensagem = "Nenhum dado encontrado!";
                }
            }
            catch (Exception ex)
            {
                // Em caso de exceção, configura a mensagem de erro na resposta
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            // Retorna a resposta do serviço
            return serviceResponse;
        }

        // Obtém uma ordem de serviço pelo ID
        public async Task<ServiceResponse<OrdemServicoModel>> GetOrdemServicoById(int id)
        {
            // Resposta do serviço
            ServiceResponse<OrdemServicoModel> serviceResponse = new();

            try
            {
                // Busca a ordem de serviço no banco de dados pelo ID, incluindo dados do operador associado
                OrdemServicoModel ordemServico = await _context.OrdensServico
                    .Include(os => os.Operador)
                    .FirstOrDefaultAsync(x => x.Id == id);

                // Se não encontrar a ordem de serviço, configura a resposta com falha
                if (ordemServico == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Ordem de Serviço não localizada!";
                    serviceResponse.Sucesso = false;
                }

                // Configura os dados na resposta
                serviceResponse.Dados = ordemServico;
            }
            catch (Exception ex)
            {
                // Em caso de exceção, configura a mensagem de erro na resposta
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            // Retorna a resposta do serviço
            return serviceResponse;
        }

        // Cria uma nova ordem de serviço
        public async Task<ServiceResponse<List<OrdemServicoModel>>> CreateOrdemServico(OrdemServicoModel novaOrdemServico)
        {
            // Resposta do serviço
            ServiceResponse<List<OrdemServicoModel>> serviceResponse = new();

            try
            {
                // Verifica se os dados da nova ordem de serviço são válidos
                if (novaOrdemServico == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Informar dados!";
                    serviceResponse.Sucesso = false;

                    // Retorna a resposta com falha
                    return serviceResponse;
                }

                // Define a data de início da nova ordem de serviço
                novaOrdemServico.DataInicio = DateTime.Now.ToLocalTime();

                // Adiciona a nova ordem de serviço ao contexto e salva as alterações no banco de dados
                _context.Add(novaOrdemServico);
                await _context.SaveChangesAsync();

                // Atualiza os dados na resposta com a lista atualizada de ordens de serviço
                serviceResponse.Dados = await _context.OrdensServico.Include(os => os.Operador).ToListAsync();
            }
            catch (Exception ex)
            {
                // Em caso de exceção, configura a mensagem de erro na resposta
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            // Retorna a resposta do serviço
            return serviceResponse;
        }

        // Atualiza uma ordem de serviço pelo ID
        public async Task<ServiceResponse<List<OrdemServicoModel>>> UpdateOrdemServico(int id, OrdemServicoModel editadaOrdemServico)
        {
            // Resposta do serviço
            ServiceResponse<List<OrdemServicoModel>> serviceResponse = new();

            try
            {
                // Busca a ordem de serviço original no banco de dados pelo ID, incluindo dados do operador associado
                OrdemServicoModel ordemServico = await _context.OrdensServico
                    .Include(os => os.Operador)
                    .FirstOrDefaultAsync(x => x.Id == id);

                // Se não encontrar a ordem de serviço, configura a resposta com falha
                if (ordemServico == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Ordem de Serviço não localizada!";
                    serviceResponse.Sucesso = false;
                }

                // Atualiza os campos da ordem de serviço com os dados da ordem editada
                ordemServico.Maquina = editadaOrdemServico.Maquina;
                ordemServico.DataConclusao = editadaOrdemServico.DataConclusao;
                ordemServico.OperadorId = editadaOrdemServico.OperadorId;
                ordemServico.Descricao = editadaOrdemServico.Descricao;
                ordemServico.DataConclusao = DateTime.Now.ToLocalTime();

                // Atualiza a ordem de serviço no contexto e salva as alterações no banco de dados
                _context.OrdensServico.Update(ordemServico);
                await _context.SaveChangesAsync();

                // Atualiza os dados na resposta com a lista atualizada de ordens de serviço
                serviceResponse.Dados = await _context.OrdensServico.Include(os => os.Operador).ToListAsync();
            }
            catch (Exception ex)
            {
                // Em caso de exceção, configura a mensagem de erro na resposta
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            // Retorna a resposta do serviço
            return serviceResponse;
        }

        // Exclui uma ordem de serviço pelo ID
        public async Task<ServiceResponse<List<OrdemServicoModel>>> DeleteOrdemServico(int id)
        {
            // Resposta do serviço
            ServiceResponse<List<OrdemServicoModel>> serviceResponse = new();

            try
            {
                // Busca a ordem de serviço no banco de dados pelo ID, incluindo dados do operador associado
                OrdemServicoModel ordemServico = await _context.OrdensServico
                    .Include(os => os.Operador)
                    .FirstOrDefaultAsync(x => x.Id == id);

                // Se não encontrar a ordem de serviço, configura a resposta com falha
                if (ordemServico == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Ordem de Serviço não localizada!";
                    serviceResponse.Sucesso = false;

                    // Retorna a resposta com falha
                    return serviceResponse;
                }

                // Remove a ordem de serviço do contexto e salva as alterações no banco de dados
                _context.OrdensServico.Remove(ordemServico);
                await _context.SaveChangesAsync();

                // Atualiza os dados na resposta com a lista atualizada de ordens de serviço
                serviceResponse.Dados = await _context.OrdensServico.Include(os => os.Operador).ToListAsync();
            }
            catch (Exception ex)
            {
                // Em caso de exceção, configura a mensagem de erro na resposta
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            // Retorna a resposta do serviço
            return serviceResponse;
        }
    }
}
