﻿using System;

namespace ApiWebDB.Services.DTOs
{
    public class EnderecoDTO
    {
        public int Cep { get; set; }

        public string Logradouro { get; set; }

        public string Numero { get; set; }

        public string Complemento { get; set; }

        public string Bairro { get; set; }

        public string Cidade { get; set; }

        public string Uf { get; set; }

        public int Clienteid { get; set; }

        public int Status { get; set; }
    }
}
