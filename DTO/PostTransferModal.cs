using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class PostTransferModal
    {
        public int UsertID { get; set; }
        public int PostID { get; set; }
        public string ImageURL { get; set; }
        public string Caption { get; set; }

        public int LikeCount { get; set; }
    }
}
