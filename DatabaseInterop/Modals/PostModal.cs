using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseInterop.Modals
{
    public class PostModal
    {
        public string ImageURL { get; set; }
        public string Caption { get; set; }
        public int UserID { get; set; }
        public int PostID { get; set; }
    }
}
