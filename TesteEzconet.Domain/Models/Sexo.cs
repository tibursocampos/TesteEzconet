using System;
using System.Collections.Generic;
using System.Text;

namespace TesteEzconet.Domain.Models
{
    public class Sexo
    {
        public int SexoId { get; set; }
        public string Descricao { get; set; }
        public Usuario User { get; set; }
    }
}
