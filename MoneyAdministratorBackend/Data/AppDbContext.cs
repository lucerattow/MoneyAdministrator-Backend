using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MoneyAdministratorBackend.Models;

namespace MoneyAdministratorBackend.Data
{
    public class AppDbContext : IdentityDbContext<Models.User>
    {
        public DbSet<CreditCardSummaryDetail> CreditCardSummaryDetails { get; set; }
        public DbSet<CreditCardSummary> CreditCardSummaries { get; set; }
        public DbSet<CreditCardBrand> CreditCardBrands { get; set; }
        public DbSet<CreditCard> CreditCards { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<CurrencyValue> CurrencyValues { get; set; }
        public DbSet<EntityType> EntityTypes { get; set; }
        public DbSet<Entity> Entities { get; set; }
        public DbSet<Salary> Salaries { get; set; }
        public DbSet<TransactionDetail> TransactionDetails { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Configuro las relaciones CreditCard
            modelBuilder.Entity<CreditCard>()
                .HasOne(x => x.User)
                .WithMany(x => x.CreditCards)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            //Configuro las FK de CreditCardSummary
            modelBuilder.Entity<CreditCardSummary>()
                .HasOne(x => x.Transaction)
                .WithMany(x => x.CreditCardSummaries)
                .HasForeignKey(x => x.TransactionId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<CreditCardSummary>()
                .HasOne(x => x.CreditCard)
                .WithMany(x => x.CreditCardSumaries)
                .HasForeignKey(x => x.CreditCardId)
                .OnDelete(DeleteBehavior.Cascade);

            //Configuro las relaciones CurrencyValue
            modelBuilder.Entity<CurrencyValue>()
                .HasOne(x => x.User)
                .WithMany(x => x.CurrencyValues)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            //Configuro las relaciones Entity
            modelBuilder.Entity<Entity>()
                .HasOne(x => x.User)
                .WithMany(x => x.Entities)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            //Configuro las relaciones EntityType
            modelBuilder.Entity<EntityType>()
                .HasOne(x => x.User)
                .WithMany(x => x.EntityTypes)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            //Configuro las relaciones Salary
            modelBuilder.Entity<Salary>()
                .HasOne(x => x.User)
                .WithMany(x => x.Salaries)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            //Configuro las relaciones Transaction
            modelBuilder.Entity<Transaction>()
                .HasOne(x => x.User)
                .WithMany(x => x.Transactions)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            ////Agrego registros predeterminados
            //modelBuilder.Entity<Currency>().HasData(
            //    new Currency { Id = 1, Name = "ARS" },
            //    new Currency { Id = 2, Name = "USD" }
            //);
            //modelBuilder.Entity<EntityType>().HasData(
            //    new EntityType { Id = 1, Name = "General" },
            //    new EntityType { Id = 2, Name = "Banco" }
            //);
            //modelBuilder.Entity<CreditCardBrand>().HasData(
            //    new CreditCardBrand { Id = 1, Name = "Visa" },
            //    new CreditCardBrand { Id = 2, Name = "MasterCard" }
            //);
        }
    }
}
