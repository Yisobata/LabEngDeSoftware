using System;
using System.Collections.Generic;

namespace entidade
{
    [Serializable]
    public class Court
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string TipoQuadra { get; set; }
        public int Capacidade { get; set; }
        public decimal ValorHora { get; set; }
        public string Descricao { get; set; }
        public DateTime DataCadastro { get; set; } = DateTime.Now;
    }
}
