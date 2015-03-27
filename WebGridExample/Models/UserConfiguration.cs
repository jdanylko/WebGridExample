using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebGridExample.Models
{
    internal class UserConfiguration : EntityTypeConfiguration<User>
    {
        public UserConfiguration(string schema = "dbo")
        {
            ToTable(schema + ".Users");
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName("Id").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.UserName).HasColumnName("UserName").IsRequired().IsUnicode(false).HasMaxLength(15);
            Property(x => x.LastLogin).HasColumnName("LastLogin").IsRequired();
            Property(x => x.FirstName).HasColumnName("FirstName").IsRequired().IsUnicode(false).HasMaxLength(20);
            Property(x => x.LastName).HasColumnName("LastName").IsRequired().IsUnicode(false).HasMaxLength(30);
        }
    }
}