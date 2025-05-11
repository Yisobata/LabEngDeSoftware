using System;

namespace LabEngSoft
{
    public class Court  // Changed from 'internal' to 'public'
    {
        public int Id { get; set; }
        public string Nome { get; set; }  // Changed from field to property
        public string Endereco { get; set; }
        public string TipoQuadra { get; set; }
        public int Capacidade { get; set; }  // Changed from field to property
        public decimal ValorHora { get; set; }  // Changed from field to property
        public string Descricao { get; set; }  // Changed from field to property
        public DateTime DataCadastro { get; set; } = DateTime.Now;
    }
}