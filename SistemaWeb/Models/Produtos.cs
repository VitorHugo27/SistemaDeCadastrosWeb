using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaWeb.Models
{
    public class Produtos
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Descricao { get; set; }

        public string Lote { get; set; }

        public Decimal Valor { get; set; }

        public string Fornecedor { get; set; }

        public int Quantidade { get; set; }

        public string Foto { get; set; }

        public DateTime DataCadastro { get; set; }
    }
}