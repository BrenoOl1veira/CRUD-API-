using API.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class OperadorModel
    {
        [Key]
        public int Id { get; set; }

        public string Nome { get; set; }

        public TurnoEnum Turno { get; set; }

        public bool Status { get; set; }

        public FuncaoEnum Funcao { get; set; }

        public DateTime DataInclusao { get; set; }

        public DateTime? DataAlteracao { get; set; }

    }
}
