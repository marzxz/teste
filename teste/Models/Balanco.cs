using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace teste.Models
{
 
    public class Balanco
    {
        public int Id { get; set; }

        public DateTime data { get; set; }

        public int valordebito { get; set; }

        public int valorcredito { get; set; }

        public int saldo { get; set; }


    }
}
