using API.Data;
using API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Services.OperadorService
{
    // Implementação da interface IOperadorInterface para operações relacionadas a operadores
    public class OperadorService : IOperadorInterface
    {
        // Contexto do banco de dados
        private readonly ApplicationDbContext _context;

        // Construtor que recebe o contexto do banco de dados
        public OperadorService(ApplicationDbContext context)
        {
            _context = context;
        }

        // Obtém um operador pelo ID
        public async Task<ServiceResponse<OperadorModel>> GetOperadorById(int id)
        {
            // Resposta do serviço
            ServiceResponse<OperadorModel> serviceResponse = new();

            try
            {
                // Busca o operador no banco de dados pelo ID
                OperadorModel operador = await _context.Operadores.FirstOrDefaultAsync(x => x.Id == id);

                // Se não encontrar o operador, configura a resposta com falha
                if (operador == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Operador não localizado!";
                    serviceResponse.Sucesso = false;
                }

                // Configura os dados na resposta
                serviceResponse.Dados = operador;
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

        // Cria um novo operador
        public async Task<ServiceResponse<List<OperadorModel>>> CreateOperador(OperadorModel novoOperador)
        {
            // Resposta do serviço
            ServiceResponse<List<OperadorModel>> serviceResponse = new();

            try
            {
                // Verifica se os dados do novo operador são válidos
                if (novoOperador == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Informar dados!";
                    serviceResponse.Sucesso = false;

                    // Retorna a resposta com falha
                    return serviceResponse;
                }

                // Define as datas de inclusão e alteração
                novoOperador.DataInclusao = DateTime.Now.ToLocalTime();
                novoOperador.DataAlteracao = DateTime.Now.ToLocalTime();

                // Adiciona o novo operador ao contexto e salva as alterações no banco de dados
                _context.Add(novoOperador);
                await _context.SaveChangesAsync();

                // Atualiza os dados na resposta com a lista atualizada de operadores
                serviceResponse.Dados = await _context.Operadores.ToListAsync();
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

        // Exclui um operador pelo ID
        public async Task<ServiceResponse<List<OperadorModel>>> DeleteOperador(int id)
        {
            // Resposta do serviço
            ServiceResponse<List<OperadorModel>> serviceResponse = new();

            try
            {
                // Busca o operador no banco de dados pelo ID
                OperadorModel operador = await _context.Operadores.FirstOrDefaultAsync(x => x.Id == id);

                // Se não encontrar o operador, configura a resposta com falha
                if (operador == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Operador não localizado!";
                    serviceResponse.Sucesso = false;

                    // Retorna a resposta com falha
                    return serviceResponse;
                }

                // Remove o operador do contexto e salva as alterações no banco de dados
                _context.Operadores.Remove(operador);
                await _context.SaveChangesAsync();

                // Atualiza os dados na resposta com a lista atualizada de operadores
                serviceResponse.Dados = await _context.Operadores.ToListAsync();
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

        // Inativa um operador pelo ID
        public async Task<ServiceResponse<List<OperadorModel>>> InativarOperador(int id)
        {
            // Resposta do serviço
            ServiceResponse<List<OperadorModel>> serviceResponse = new();

            try
            {
                // Busca o operador no banco de dados pelo ID
                OperadorModel operador = await _context.Operadores.FirstOrDefaultAsync(x => x.Id == id);

                // Se não encontrar o operador, configura a resposta com falha
                if (operador == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Operador não localizado!";
                    serviceResponse.Sucesso = false;

                    // Retorna a resposta com falha
                    return serviceResponse;
                }

                // Inativa o operador e define a data de alteração
                operador.Status = false;
                operador.DataAlteracao = DateTime.Now.ToLocalTime();

                // Atualiza o operador no contexto e salva as alterações no banco de dados
                _context.Operadores.Update(operador);
                await _context.SaveChangesAsync();

                // Atualiza os dados na resposta com a lista atualizada de operadores
                serviceResponse.Dados = await _context.Operadores.ToListAsync();
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

        // Obtém a lista de todos os operadores
        public async Task<ServiceResponse<List<OperadorModel>>> GetOperadores()
        {
            // Resposta do serviço
            ServiceResponse<List<OperadorModel>> serviceResponse = new();

            try
            {
                // Obtém todos os operadores do banco de dados
                serviceResponse.Dados = await _context.Operadores.ToListAsync();

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

        // Atualiza um operador pelo ID
        public async Task<ServiceResponse<List<OperadorModel>>> UpdateOperador(int id, OperadorModel editadoOperador)
        {
            // Resposta do serviço
            ServiceResponse<List<OperadorModel>> serviceResponse = new();

            try
            {
                // Busca o operador original no banco de dados pelo ID
                OperadorModel operador = await _context.Operadores.AsNoTracking().FirstOrDefaultAsync(x => x.Id == editadoOperador.Id);

                // Se não encontrar o operador, configura a resposta com falha
                if (operador == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Operador não localizado!";
                    serviceResponse.Sucesso = false;
                }

                // Define a data de alteração no operador editado
                editadoOperador.DataAlteracao = DateTime.Now.ToLocalTime();

                // Atualiza o operador no contexto e salva as alterações no banco de dados
                _context.Operadores.Update(editadoOperador);
                await _context.SaveChangesAsync();

                // Atualiza os dados na resposta com a lista atualizada de operadores
                serviceResponse.Dados = await _context.Operadores.ToListAsync();
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
