using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace teste.Models
{   
    public class Financeiro
    {
        public int Id { get; set; }

        public DateTime datahora { get; set; }

        public string valor { get; set; }

        public string tipo { get; set; }

        public string status { get; set; }

    }
}
