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
            // NB : La DAL ne doit PAS être référencée directement. la BLL doit faire l'intermédiaire.
            // C'est fait à titre de test et démo.

            ProviderPersonne provider = new ProviderPersonne();
            provider.Create(new DTO.EntityPersonne { Nom = "DUPONT", Prenom = "Martin", Age = 30 });

            // L'utilisation des lambdas permets de requetes sur toutes les propriétés possibles avec une seule fonction
            // évitant ainsi de faire un besoin = une fonction
            EntityPersonne maPersonne = provider.GetEntityByPredicateFirst(p => p.Nom == "DUPONT");
        }
    }
}
