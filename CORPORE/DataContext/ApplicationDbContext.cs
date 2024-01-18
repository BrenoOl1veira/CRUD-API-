using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    /// <summary>
    /// Contexto de banco de dados para a aplicação, contendo as DbSet correspondentes às entidades do modelo.
    /// </summary>
    public class ApplicationDbContext : DbContext
    {
        /// <summary>
        /// Conjunto de dados representando os operadores.
        /// </summary>
        public DbSet<OperadorModel> Operadores { get; set; }

        /// <summary>
        /// Conjunto de dados representando as ordens de serviço.
        /// </summary>
        public DbSet<OrdemServicoModel> OrdensServico { get; set; }

        /// <summary>
        /// Construtor que recebe as opções de configuração do contexto.
        /// </summary>
        /// <param name="options">Opções de configuração do contexto.</param>
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        /// <summary>
        /// Configurações adicionais do modelo durante a criação do contexto.
        /// </summary>
        /// <param name="modelBuilder">Construtor do modelo.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuração do relacionamento entre OrdemServicoModel e OperadorModel
            modelBuilder.Entity<OrdemServicoModel>()
                .HasOne(os => os.Operador)
                .WithMany()
                .HasForeignKey(os => os.OperadorId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
