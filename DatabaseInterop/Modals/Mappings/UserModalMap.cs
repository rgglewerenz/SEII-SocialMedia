using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseInterop.Modals.Mappings
{
    public class UserModalMap : EntityTypeConfiguration<UserModal>
    {
        public UserModalMap() {
            this.HasKey(t => t.UserID);
            this.Property(t => t.Email).IsRequired().HasMaxLength(255);
            this.Property(t => t.PasswordHash).IsRequired().HasMaxLength(255);

            this.ToTable("userAuth");

            this.Property(t => t.UserID).HasColumnName("user_id");
            this.Property(t => t.Email).HasColumnName("email");
            this.Property(t => t.PasswordHash).HasColumnName("password");
        }

    }
}
