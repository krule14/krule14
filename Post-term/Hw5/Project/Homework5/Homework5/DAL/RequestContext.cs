    using System;
    using System.Data.Entity;
    using System.Linq;
using Homework5.Models;
namespace Homework5.DAL
{
    public class RequestContext : DbContext
    { // Your context has been configured to use a 'RequestContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'Homework5.DAL.RequestContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'RequestContext' 
        // connection string in the application configuration file.
        public RequestContext() : base("name=OurRequests")
        {

        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<Request> Requests { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}