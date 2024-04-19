using GenericRepository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ProductManagementTask.Domain.Entities;
using ProductManagementTask.Domain.Enums;

namespace ProductManagementTask.Infrastructure.Context;
internal sealed class ApplicationDbContext : DbContext,IUnitOfWork
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<StockType> StockTypes { get; set; }
    public DbSet<StockUnit> StockUnits { get; set; }
    public DbSet<Stock> Stocks {  get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Stock>()
            .Property(p => p.StockClass)
            .HasConversion(stock => stock.Value, value => StockClassEnum.FromValue(value));

        modelBuilder.Entity<StockUnit>()
            .Property(p => p.QuantityUnit)
            .HasConversion(unit => unit.Value, value => QuantityUnitEnum.FromValue(value));

        modelBuilder.Entity<StockUnit>()
            .OwnsOne(p => p.Buying, buyingBuilder =>
            {
                buyingBuilder
                .Property(p => p.currency)
                .HasConversion(currency => currency.Value, value => MoneyTypeEnum.FromValue(value))
                .HasColumnName("BuyingCurrency");

                buyingBuilder
                .Property(p => p.Amount)
                .HasColumnName("BuyingAmount")
                .HasColumnType("money");
                
            });

        modelBuilder.Entity<StockUnit>()
           .OwnsOne(p => p.Selling, sellingBuilder =>
           {
               sellingBuilder
               .Property(p => p.currency)
               .HasConversion(currency => currency.Value, value => MoneyTypeEnum.FromValue(value))
               .HasColumnName("SellingCurrency");

               sellingBuilder
               .Property(p => p.Amount)
               .HasColumnName("SellingAmount")
               .HasColumnType("money");

           });

        modelBuilder.Entity<Stock>()
            .HasOne(s => s.StockType)
            .WithMany()
            .HasForeignKey(s => s.StockTypeId)
            .OnDelete(DeleteBehavior.NoAction);


        //modelBuilder.Entity<Stock>()
        //    .HasOne(s => s.StockUnit)
        //    .WithMany()
        //    .HasForeignKey(s => s.StockUnitId)
        //    .OnDelete(DeleteBehavior.NoAction);

    }
}
