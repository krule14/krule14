namespace Homework7.DAL
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Homework7.Models;

    public class RequestLogContext : DbContext
    {
         public RequestLogContext()
            : base("name=RequestLogContext")
        {
        }

        public virtual DbSet<RequestLog> RequestLogs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }

    
}