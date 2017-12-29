using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RestauranteWebApplication.Models
{
    public class Restaurante
    {

        public int ID { get; set; }
        public string Descricao { get; set; }
        public ICollection<Prato> Pratos { get; set; }
    }
}
