using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestauranteWebApplication.Models
{
    public class Prato
    {
        public int ID { get; set; }
        public string Descricao { get; set; }
        public float Preco { get; set; }
    }
}
