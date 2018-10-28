using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boootcamp20.Models
{
    class DetailPenjualan : BaseModel
    {
        public int Qyt { get; set; }
        public int Price { get; set; }
        public int Total { get; set; }
        public Penjualan Penjualann { get; set; }
        public Item Items { get; set; }

    }
}
