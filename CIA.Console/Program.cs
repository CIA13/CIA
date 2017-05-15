using CIA.DAL;
using CIA.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIA.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            ProviderPersonne provider = new ProviderPersonne();
            provider.Create(new DTO.EntityPersonne { Nom = "DUPONT", Prenom = "Martin", Age = 30 });

            EntityPersonne maPersonne = provider.GetEntityByPredicateFirst(p => p.Nom == "DUPONT");
        }
    }
}
