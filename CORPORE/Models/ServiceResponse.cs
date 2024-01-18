namespace API.Models
{
    // Modelo genérico para respostas de serviços
    public class ServiceResponse<T>
    {
        // Dados da resposta (pode ser nulo)
        public T Dados { get; set; }

        // Mensagem associada à resposta
        public string Mensagem { get; set; } = string.Empty;

        // Indica se a operação foi bem-sucedida
        public bool Sucesso { get; set; } = true;
    }
}
