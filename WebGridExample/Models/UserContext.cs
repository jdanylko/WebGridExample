using System.Data.Entity;
using WebGridExample.Interface;

namespace WebGridExample.Models
{
    public class UserContext : DbContext, IUserContext
    {
        public IDbSet<User> Users { get; set; } // Users

        static UserContext()
        {
            Database.SetInitializer<UserContext>(null);
        }

        public UserContext()
            : base("Name=UserContext")
        {
        }

        public UserContext(string connectionString) : base(connectionString)
        {
        }

        public UserContext(string connectionString, System.Data.Entity.Infrastructure.DbCompiledModel model) : base(connectionString, model)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new UserConfiguration());
        }

        public static DbModelBuilder CreateModel(DbModelBuilder modelBuilder, string schema)
        {
            modelBuilder.Configurations.Add(new UserConfiguration(schema));
            return modelBuilder;
        }
        
        // Stored Procedures
    }
}