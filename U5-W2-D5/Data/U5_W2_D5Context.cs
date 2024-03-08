using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using U5_W2_D5.Models;

namespace U5_W2_D5.Data
{
    public class U5_W2_D5Context : DbContext
    {
        public U5_W2_D5Context (DbContextOptions<U5_W2_D5Context> options)
            : base(options)
        {
        }

        public DbSet<U5_W2_D5.Models.Camera> Camera { get; set; } = default!;
        public DbSet<U5_W2_D5.Models.Clienti> Clienti { get; set; } = default!;
        public DbSet<U5_W2_D5.Models.Login> Login { get; set; } = default!;
        public DbSet<U5_W2_D5.Models.Pensione> Pensione { get; set; } = default!;
        public DbSet<U5_W2_D5.Models.Prenotazione> Prenotazione { get; set; } = default!;
        public DbSet<U5_W2_D5.Models.Servizi> Servizi { get; set; } = default!;
        public DbSet<U5_W2_D5.Models.CheckoutViewModel> CheckoutViewModel { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<CheckoutViewModel>().HasNoKey();
        }
    }
}
