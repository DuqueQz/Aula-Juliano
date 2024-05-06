﻿using System;
using System.Collections.Generic;
using System.Linq;
using Trabalho_2.Classes;
using T2.Interfaces;

namespace Trabalho_2.Relatorios
{
    public class EstoqueSeguranca : IRelatorio
    {
        public List<Produto> Imprimir(List<Produto> produtos)
        {
            return produtos.Where(p => p.Estoque < p.QtdVendida * 0.33).ToList();
            
        }
    }
}