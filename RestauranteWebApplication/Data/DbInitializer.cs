using RestauranteWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestauranteWebApplication.Data
{
    public class DbInitializer
    {
        public static void Initialize(BdContext context) {
            context.Database.EnsureCreated();


            if (context.Pratos.Any())
            {
                return;   // DB has been seeded
            }


            Prato prato = new Prato();
            prato.Descricao = "Teste";
            prato.Preco = 1;

            Prato prato1 = new Prato();
            prato.Descricao = "Teste1";
            prato.Preco = 1;


            Restaurante r = new Restaurante();

            r.Descricao = "testes";
            context.Restarantes.Add(r);

            context.Pratos.Add(prato);

            context.Pratos.Add(prato1);

            context.SaveChanges();
        }

    }
}
