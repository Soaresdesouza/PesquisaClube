using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PesquisaClube.Models
{
    public class Clube
    {
        public int ClubeId { get; set; }

        public string ClubeNome { get; set; }

        public int Qtde { get; set; }

        [NotMapped]
        public bool CheckboxMarcado { get; set; }
    }
}
