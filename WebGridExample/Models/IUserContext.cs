using System;
using System.Data.Entity;

namespace WebGridExample.Models
{
    public interface IUserContext : IDisposable
    {
        IDbSet<User> Users { get; set; } // Users

        int SaveChanges();
        
        // Stored Procedures
    }
}