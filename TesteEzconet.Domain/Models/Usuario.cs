﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace TesteEzconet.Domain.Models
{
    public class Usuario
    {
        public Usuario()
        {
            //Sexos = new Collection<Sexo>();
            Ativo = true;
        }
        public int UsuarioId { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public bool Ativo { get; set; }
        public int SexoId { get; set; }
        public virtual Sexo Sexos { get; set; }
    }
}
