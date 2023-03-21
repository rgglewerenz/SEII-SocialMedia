using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseInterop.Modals.Mappings
{
    public class PostModalMap : EntityTypeConfiguration<PostModal>
    {
        public PostModalMap()
        {

            this.HasKey(t => t.PostID);
            this.Property(t => t.ImageURL).HasMaxLength(255);
            this.Property(t => t.Caption).HasMaxLength(255);
            this.Property(t => t.UserID).IsRequired();

            this.ToTable("posts");

            this.Property(t => t.UserID).HasColumnName("user_id");
            this.Property(t => t.ImageURL).HasColumnName("image_url");
            this.Property(t => t.Caption).HasColumnName("caption");
            this.Property(t => t.PostID).HasColumnName("post_id");

        }
    }
}
