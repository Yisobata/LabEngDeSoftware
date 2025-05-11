using System;
using System.Collections.Generic;
using System.Linq;

namespace LabEngSoft
{
    public static class CourtRepository  // Made class static since all methods are static
    {
        private static List<Court> _courts = new List<Court>();
        private static int _nextId = 1;


        static CourtRepository()
        {
            // Initialize with sample data
            _courts = new List<Court>
        {
            new Court {
                Nome = "Quadra Central",
                Endereco = "Rua A, 123",
                TipoQuadra = "Futebol",
                Capacidade = 20,
                ValorHora = 80.00m,
                Descricao = "Quadra oficial de futebol",
                DataCadastro = DateTime.Now.AddDays(-5)
            },
            new Court {
                Nome = "Quadra Premium",
                Endereco = "Av. B, 456",
                TipoQuadra = "Vôlei",
                Capacidade = 15,
                ValorHora = 120.00m,
                Descricao = "Quadra de vôlei profissional",
                DataCadastro = DateTime.Now.AddDays(-3)
            },
            new Court {
                Nome = "Quadra Básica",
                Endereco = "Praça C, 789",
                TipoQuadra = "Basquete",
                Capacidade = 10,
                ValorHora = 50.00m,
                Descricao = "Quadra de basquete simples",
                DataCadastro = DateTime.Now.AddDays(-1)
            }
        };

            // Set IDs for the sample data
            foreach (var court in _courts)
            {
                court.Id = _nextId++;
            }
        }
        public static Court GetById(int id)
        {
            return _courts.FirstOrDefault(c => c.Id == id);
        }

        public static void Add(Court court)
        {
            court.Id = _nextId++;
            _courts.Add(court);
        }

        public static void Update(Court updatedCourt)
        {
            var existing = GetById(updatedCourt.Id);
            if (existing != null)
            {
                existing.Nome = updatedCourt.Nome;
                existing.Endereco = updatedCourt.Endereco;
                existing.TipoQuadra = updatedCourt.TipoQuadra;
                existing.Capacidade = updatedCourt.Capacidade;
                existing.ValorHora = updatedCourt.ValorHora;
                existing.Descricao = updatedCourt.Descricao;
            }
        }

        public static List<Court> GetAll()
        {
            return _courts.OrderByDescending(c => c.DataCadastro).ToList();
        }

        public static List<Court> GetAllSorted(string sortExpression = "DataCadastro DESC")
        {
            IQueryable<Court> query = _courts.AsQueryable();

            switch (sortExpression)
            {
                case "PrecoAsc":
                    query = query.OrderBy(c => c.ValorHora);
                    break;
                case "PrecoDesc":
                    query = query.OrderByDescending(c => c.ValorHora);
                    break;
                case "DataAsc":
                    query = query.OrderBy(c => c.DataCadastro);
                    break;
                default: // Default sorting by newest first
                    query = query.OrderByDescending(c => c.DataCadastro);
                    break;
            }

            return query.ToList();
        }
    }
}