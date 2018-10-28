using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boootcamp20.Models
{
    class Penjualan 
    {
        [Key]
        public int Id { get; set; }
        public int Total { get; set; }
    }
}
