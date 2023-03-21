using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseInterop.Modals.Mappings
{
    public class PostLikeModalMap : EntityTypeConfiguration<PostLikeModal>
    {
        public PostLikeModalMap() {
            this.HasKey(t => t.PostID);
            this.Property(t => t.LikeID).IsRequired();
            this.Property(t => t.UserID).IsRequired();

            this.ToTable("post_likes");

            this.Property(t => t.UserID).HasColumnName("user_id");
            this.Property(t => t.LikeID).HasColumnName("like_id");
            this.Property(t => t.PostID).HasColumnName("post_id");

        }
    }
}
