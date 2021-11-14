using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class ViewModel
    {
        public IEnumerable<Writer> Writers { get; set; }
        public IEnumerable<City> Cities { get; set; }
    }
}
