using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace TesteEzconet.Domain.Models
{
    public class Sexo
    {
        public Sexo()
        {
            Usuarios = new Collection<Usuario>();
        }
        public int SexoId { get; set; }
        public string Descricao { get; set; }
        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
