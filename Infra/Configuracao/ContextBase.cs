using Entities.Entidades;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Configuracao
{
    public class ContextBase : IdentityDbContext<ApplicationUser>
    {
        //Construtor
        public ContextBase( DbContextOptions options): base(options) {

        }

        public DbSet<SistemaFinanceiro> SistemaFinanceiro { get; set; }
        public DbSet<UsuarioSistemaFinanceiro> UsuarioSistemaFinanceiro { get; set; }
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Despesa> Despesa { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ObterStringConexao());

                optionsBuilder.UseSqlServer(@"Data Source=localhost;Initial Catalog=FINANCEIRO_2023;Integrated Security=False;User ID=sa;Password=BW9512bw;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False");

                base.OnConfiguring(optionsBuilder);
            }                        
        }

        //Para mapear qual o ID da tabela AspNetUsers para tabela ApplicationUser]
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ApplicationUser>().ToTable("AspNetUsers").HasKey(t => t.Id);

            base.OnModelCreating(builder);
        }

        public string ObterStringConexao()
        {
            return "Data Source=localhost;Initial Catalog=FINANCEIRO_2023;Integrated Security=False;User ID=sa;Password=BW9512bw;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False";
        }


    }
}
