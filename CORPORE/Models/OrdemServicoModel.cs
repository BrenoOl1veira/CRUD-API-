using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    public class OrdemServicoModel
    {
        [Key]
        public int Id { get; set; }
        public string Maquina { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime? DataConclusao { get; set; }

        [ForeignKey("Operador")]
        public int OperadorId { get; set; }
        public OperadorModel Operador { get; set; }

        public string Descricao { get; set; }
    }
}
