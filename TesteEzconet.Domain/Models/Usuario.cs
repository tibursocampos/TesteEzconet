﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TesteEzconet.Domain.Models
{
    public class Usuario
    {
        public int UsuarioId { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public bool Ativo { get; set; }
        public int SexoId { get; set; }
        public Sexo SexoUsuario { get; set; }
    }
}
