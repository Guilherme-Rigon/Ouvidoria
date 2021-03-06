using Microsoft.EntityFrameworkCore;
using Ouvidoria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ouvidoria.Data.Semeador
{
    public static class Semeador
    {
        public static void InicializarTabelas(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Perfil>().HasData(
                new Perfil { PerfilId = 1, Nome = "Aluno" },
                new Perfil { PerfilId = 2, Nome = "Pais de Aluno" },
                new Perfil { PerfilId = 3, Nome = "Professor" },
                new Perfil { PerfilId = 4, Nome = "Funcionário" },
                new Perfil { PerfilId = 5, Nome = "Visitante" }
                );
            modelBuilder.Entity<TipoSolicitacao>().HasData(
                new TipoSolicitacao { TipoSolicitacaoId = 1, Nome = "Elogio" },
                new TipoSolicitacao { TipoSolicitacaoId = 2, Nome = "Reclamação" },
                new TipoSolicitacao { TipoSolicitacaoId = 3, Nome = "Sugestão" },
                new TipoSolicitacao { TipoSolicitacaoId = 4, Nome = "Outro" }
                );
            modelBuilder.Entity<Setor>().HasData(
                new Setor { SetorId = 1, Nome = "Biblioteca", Email = "biblioteca@gmail.com" },
                new Setor { SetorId = 2, Nome = "Centro de Atendimento", Email = "centroatendimento@gmail.com" },
                new Setor { SetorId = 3, Nome = "Financeiro", Email = "financeiro@gmail.com" }
                );
            modelBuilder.Entity<Manifestacao>().HasData(
                new Manifestacao 
                { 
                    ManifestacaoId = 1, 
                    SetorId = 1, 
                    TipoSolicitacaoId = 1, 
                    PerfilId = 1, 
                    Nome = "Guilherme Luiz Simões Rigon",
                    Email = "guilherme.rigon1988@gmail.com",
                    Telefone = "(24)3350-4146",
                    Celular = "(24)99922-5355",
                    Assunto = "Grande Disponibilidade de Livros",
                    Campus = "UGB-VR",
                    Detalhe = "É a maior e melhor biblioteca que vi entre as 3 unidades",
                },
                new Manifestacao
                {
                    ManifestacaoId = 2,
                    SetorId = 3,
                    TipoSolicitacaoId = 3,
                    PerfilId = 2,
                    Nome = "João Figueiredo",
                    Email = "joao@joao.com",
                    Telefone = "(24)3350-4146",
                    Celular = "(24)99922-5355",
                    Assunto = "Mensalidade",
                    Campus = "UGB-VR",
                    Detalhe = "Permitir débito em conta.",
                }
                );
        }
    }
}
