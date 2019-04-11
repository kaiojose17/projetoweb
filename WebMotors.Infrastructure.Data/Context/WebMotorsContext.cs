using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebMotors.Domain.Entities;

namespace WebMotors.Infrastructure.Data.Context
{
    public class WebMotorsContext : DbContext
    {
        public WebMotorsContext()
            : base("WebMotorsConnection")
        {
        }

        public DbSet<AnuncioWebMotors> AnuncioWebMotors { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Properties<string>()
                .Configure(b => b.HasColumnType("varchar"));
        }
    }
}
