namespace Homework8.DAL
{
    using Homework8.Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class AuctionContext : DbContext
    {
        // Your context has been configured to use a 'AuctionContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'Homework8.DAL.AuctionContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'AuctionContext' 
        // connection string in the application configuration file.
        public AuctionContext()
            : base("name=AuctionContext1")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<Bid> Bids { get; set; }
        public virtual DbSet<Buyer> Buyers { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<Seller> Sellers { get; set; }
        
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}