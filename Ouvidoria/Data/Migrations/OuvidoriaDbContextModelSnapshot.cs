﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Ouvidoria.Data;

namespace Ouvidoria.Data.Migrations
{
    [DbContext(typeof(OuvidoriaDbContext))]
    partial class OuvidoriaDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Ouvidoria.Models.Manifestacao", b =>
                {
                    b.Property<long>("ManifestacaoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Assunto")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime>("AtualizadoEm")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CadastradoEm")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2");

                    b.Property<string>("Campus")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Celular")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Curso")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Detalhe")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<long>("PerfilId")
                        .HasColumnType("bigint");

                    b.Property<long>("SetorId")
                        .HasColumnType("bigint");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<long>("TipoSolicitacaoId")
                        .HasColumnType("bigint");

                    b.HasKey("ManifestacaoId");

                    b.HasIndex("PerfilId");

                    b.HasIndex("SetorId");

                    b.HasIndex("TipoSolicitacaoId");

                    b.ToTable("Manifestacoes");

                    b.HasData(
                        new
                        {
                            ManifestacaoId = 1L,
                            Assunto = "Grande Disponibilidade de Livros",
                            AtualizadoEm = new DateTime(2021, 3, 6, 15, 33, 49, 515, DateTimeKind.Local).AddTicks(8692),
                            CadastradoEm = new DateTime(2021, 3, 6, 15, 33, 49, 515, DateTimeKind.Local).AddTicks(8687),
                            Campus = "UGB-VR",
                            Celular = "(24)99922-5355",
                            Detalhe = "É a maior e melhor biblioteca que vi entre as 3 unidades",
                            Email = "guilherme.rigon1988@gmail.com",
                            Nome = "Guilherme Luiz Simões Rigon",
                            PerfilId = 1L,
                            SetorId = 1L,
                            Telefone = "(24)3350-4146",
                            TipoSolicitacaoId = 1L
                        },
                        new
                        {
                            ManifestacaoId = 2L,
                            Assunto = "Mensalidade",
                            AtualizadoEm = new DateTime(2021, 3, 6, 15, 33, 49, 516, DateTimeKind.Local).AddTicks(3478),
                            CadastradoEm = new DateTime(2021, 3, 6, 15, 33, 49, 516, DateTimeKind.Local).AddTicks(3473),
                            Campus = "UGB-VR",
                            Celular = "(24)99922-5355",
                            Detalhe = "Permitir débito em conta.",
                            Email = "joao@joao.com",
                            Nome = "João Figueiredo",
                            PerfilId = 2L,
                            SetorId = 3L,
                            Telefone = "(24)3350-4146",
                            TipoSolicitacaoId = 3L
                        });
                });

            modelBuilder.Entity("Ouvidoria.Models.Perfil", b =>
                {
                    b.Property<long>("PerfilId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("AtualizadoEm")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CadastradoEm")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.HasKey("PerfilId");

                    b.ToTable("Perfis");

                    b.HasData(
                        new
                        {
                            PerfilId = 1L,
                            AtualizadoEm = new DateTime(2021, 3, 6, 15, 33, 49, 513, DateTimeKind.Local).AddTicks(4733),
                            CadastradoEm = new DateTime(2021, 3, 6, 15, 33, 49, 512, DateTimeKind.Local).AddTicks(3733),
                            Nome = "Aluno"
                        },
                        new
                        {
                            PerfilId = 2L,
                            AtualizadoEm = new DateTime(2021, 3, 6, 15, 33, 49, 513, DateTimeKind.Local).AddTicks(6371),
                            CadastradoEm = new DateTime(2021, 3, 6, 15, 33, 49, 513, DateTimeKind.Local).AddTicks(6354),
                            Nome = "Pais de Aluno"
                        },
                        new
                        {
                            PerfilId = 3L,
                            AtualizadoEm = new DateTime(2021, 3, 6, 15, 33, 49, 513, DateTimeKind.Local).AddTicks(6395),
                            CadastradoEm = new DateTime(2021, 3, 6, 15, 33, 49, 513, DateTimeKind.Local).AddTicks(6394),
                            Nome = "Professor"
                        },
                        new
                        {
                            PerfilId = 4L,
                            AtualizadoEm = new DateTime(2021, 3, 6, 15, 33, 49, 513, DateTimeKind.Local).AddTicks(6397),
                            CadastradoEm = new DateTime(2021, 3, 6, 15, 33, 49, 513, DateTimeKind.Local).AddTicks(6396),
                            Nome = "Funcionário"
                        },
                        new
                        {
                            PerfilId = 5L,
                            AtualizadoEm = new DateTime(2021, 3, 6, 15, 33, 49, 513, DateTimeKind.Local).AddTicks(6400),
                            CadastradoEm = new DateTime(2021, 3, 6, 15, 33, 49, 513, DateTimeKind.Local).AddTicks(6399),
                            Nome = "Visitante"
                        });
                });

            modelBuilder.Entity("Ouvidoria.Models.Resposta", b =>
                {
                    b.Property<long>("RespostaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("AtualizadoEm")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CadastradoEm")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2");

                    b.Property<string>("CaminhoAnexo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContentType")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Conteudo")
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<long>("ManifestacaoId")
                        .HasColumnType("bigint");

                    b.HasKey("RespostaId");

                    b.HasIndex("ManifestacaoId");

                    b.ToTable("Respostas");
                });

            modelBuilder.Entity("Ouvidoria.Models.Setor", b =>
                {
                    b.Property<long>("SetorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("AtualizadoEm")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CadastradoEm")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.HasKey("SetorId");

                    b.ToTable("Setores");

                    b.HasData(
                        new
                        {
                            SetorId = 1L,
                            AtualizadoEm = new DateTime(2021, 3, 6, 15, 33, 49, 515, DateTimeKind.Local).AddTicks(6535),
                            CadastradoEm = new DateTime(2021, 3, 6, 15, 33, 49, 515, DateTimeKind.Local).AddTicks(6530),
                            Email = "biblioteca@gmail.com",
                            Nome = "Biblioteca"
                        },
                        new
                        {
                            SetorId = 2L,
                            AtualizadoEm = new DateTime(2021, 3, 6, 15, 33, 49, 515, DateTimeKind.Local).AddTicks(7941),
                            CadastradoEm = new DateTime(2021, 3, 6, 15, 33, 49, 515, DateTimeKind.Local).AddTicks(7936),
                            Email = "centroatendimento@gmail.com",
                            Nome = "Centro de Atendimento"
                        },
                        new
                        {
                            SetorId = 3L,
                            AtualizadoEm = new DateTime(2021, 3, 6, 15, 33, 49, 515, DateTimeKind.Local).AddTicks(7986),
                            CadastradoEm = new DateTime(2021, 3, 6, 15, 33, 49, 515, DateTimeKind.Local).AddTicks(7985),
                            Email = "financeiro@gmail.com",
                            Nome = "Financeiro"
                        });
                });

            modelBuilder.Entity("Ouvidoria.Models.TipoSolicitacao", b =>
                {
                    b.Property<long>("TipoSolicitacaoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("AtualizadoEm")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CadastradoEm")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.HasKey("TipoSolicitacaoId");

                    b.ToTable("TiposSolicitacao");

                    b.HasData(
                        new
                        {
                            TipoSolicitacaoId = 1L,
                            AtualizadoEm = new DateTime(2021, 3, 6, 15, 33, 49, 515, DateTimeKind.Local).AddTicks(4612),
                            CadastradoEm = new DateTime(2021, 3, 6, 15, 33, 49, 515, DateTimeKind.Local).AddTicks(4602),
                            Nome = "Elogio"
                        },
                        new
                        {
                            TipoSolicitacaoId = 2L,
                            AtualizadoEm = new DateTime(2021, 3, 6, 15, 33, 49, 515, DateTimeKind.Local).AddTicks(5780),
                            CadastradoEm = new DateTime(2021, 3, 6, 15, 33, 49, 515, DateTimeKind.Local).AddTicks(5774),
                            Nome = "Reclamação"
                        },
                        new
                        {
                            TipoSolicitacaoId = 3L,
                            AtualizadoEm = new DateTime(2021, 3, 6, 15, 33, 49, 515, DateTimeKind.Local).AddTicks(5802),
                            CadastradoEm = new DateTime(2021, 3, 6, 15, 33, 49, 515, DateTimeKind.Local).AddTicks(5801),
                            Nome = "Sugestão"
                        },
                        new
                        {
                            TipoSolicitacaoId = 4L,
                            AtualizadoEm = new DateTime(2021, 3, 6, 15, 33, 49, 515, DateTimeKind.Local).AddTicks(5805),
                            CadastradoEm = new DateTime(2021, 3, 6, 15, 33, 49, 515, DateTimeKind.Local).AddTicks(5804),
                            Nome = "Outro"
                        });
                });

            modelBuilder.Entity("Ouvidoria.Models.Manifestacao", b =>
                {
                    b.HasOne("Ouvidoria.Models.Perfil", "Perfil")
                        .WithMany("Manifestacoes")
                        .HasForeignKey("PerfilId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Ouvidoria.Models.Setor", "Setor")
                        .WithMany("Manifestacoes")
                        .HasForeignKey("SetorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Ouvidoria.Models.TipoSolicitacao", "TipoSolicitacao")
                        .WithMany("Manifestacoes")
                        .HasForeignKey("TipoSolicitacaoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Perfil");

                    b.Navigation("Setor");

                    b.Navigation("TipoSolicitacao");
                });

            modelBuilder.Entity("Ouvidoria.Models.Resposta", b =>
                {
                    b.HasOne("Ouvidoria.Models.Manifestacao", "Manifestacao")
                        .WithMany("Respostas")
                        .HasForeignKey("ManifestacaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Manifestacao");
                });

            modelBuilder.Entity("Ouvidoria.Models.Manifestacao", b =>
                {
                    b.Navigation("Respostas");
                });

            modelBuilder.Entity("Ouvidoria.Models.Perfil", b =>
                {
                    b.Navigation("Manifestacoes");
                });

            modelBuilder.Entity("Ouvidoria.Models.Setor", b =>
                {
                    b.Navigation("Manifestacoes");
                });

            modelBuilder.Entity("Ouvidoria.Models.TipoSolicitacao", b =>
                {
                    b.Navigation("Manifestacoes");
                });
#pragma warning restore 612, 618
        }
    }
}
