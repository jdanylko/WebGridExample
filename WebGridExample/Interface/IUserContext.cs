using System;
using System.Data.Entity;
using WebGridExample.Models;

namespace WebGridExample.Interface
{
    public interface IUserContext : IDisposable
    {
        IDbSet<User> Users { get; set; } // Users

        int SaveChanges();
        
        // Stored Procedures
    }
}