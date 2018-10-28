using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boootcamp20.Models
{
    class Item : BaseModel
    {
        
        public String Name { get; set; }
        public int Price { get; set; }
        public int Stock { get; set; }
        public Supplier Suppliers { get; set; }
    }
}
