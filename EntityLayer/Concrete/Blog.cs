using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Blog
    {
        [Key]
        public int BlogID { get; set; }
        public string BlogTitle { get; set; }
        public string BlogContent { get; set; }
        //küçük resim
        public string BlogThumbNailImage{ get; set; }
        //normal resim
        public string BlogImage { get; set; }
        public DateTime BlogCreateDate { get; set; }
        public bool BlogStatus { get; set; }
        //bir Category ye blog yapmak için 
        public int CategoryID { get; set; }
        public Category Category  { get; set; }
        //bir bloga birden fazla yorum yapılabilir.
        public List<Comment> Comments{ get; set; }

    }

}
