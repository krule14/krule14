namespace Homework8Troubleshoot.DAL
{
    using Homework8Troubleshoot.Models;
    using System;
    using System.Data.Entity;
    using System.Linq;
    

    public class AuctionHouseContext : DbContext
    {
        // Your context has been configured to use a 'AuctionHouseContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'Homework8Troubleshoot.DAL.AuctionHouseContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'AuctionHouseContext' 
        // connection string in the application configuration file.
        public AuctionHouseContext()
            : base("name=AuctionHouseContext")
        {
        }

        public virtual DbSet<Bid> Bid { get; set; }
        public virtual DbSet<Buyer> Buyer { get; set; }
        public virtual DbSet<Item> Item { get; set; }
        public virtual DbSet<Seller> Seller { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Buyer>()
                .HasMany(e => e.Bid1)
                .WithRequired(e => e.Buyer1)
                .HasForeignKey(e => e.Buyer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Item>()
                .HasMany(e => e.Bid)
                .WithRequired(e => e.Item1)
                .HasForeignKey(e => e.Item)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Seller>()
                .HasMany(e => e.Item)
                .WithRequired(e => e.Seller1)
                .HasForeignKey(e => e.Seller)
                .WillCascadeOnDelete(false);
        }
    }

   
}