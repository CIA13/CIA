using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIA.DTO
{
    public class EntitySociete
    {
        public int ID { get; set; }
        public string RaisonSociale { get; set; }
        public int SIREN { get; set; }
        public string Adresse { get; set; }
        public virtual List<EntityPersonne> Employes { get; set; }

        public EntitySociete()
        {
            Employes = new List<EntityPersonne>();
        }
    }
}
