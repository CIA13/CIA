using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIA.DTO
{
    public class EntitySociete
    {
        /// <summary>
        /// PK
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// Raison sociale de la société
        /// </summary>
        public string RaisonSociale { get; set; }
        /// <summary>
        /// Numéro de SIREN
        /// </summary>        
        public int SIREN { get; set; }

        /// <summary>
        /// Adresse de la société
        /// </summary>
        /// Il est possible d'utiliser une expression rationnelle pour forcer des formatages spécifiques
        /// [RegularExpression("")]
        public string Adresse { get; set; }

        /// <summary>
        /// la liste des employés travaillant dans la société
        /// Le mot clé virtual sert à activer le LazyLoading (chargement des objets Employes uniquement en cas d'accès à la liste)
        /// </summary>
        public virtual List<EntityPersonne> Employes { get; set; }

        public EntitySociete()
        {
            Employes = new List<EntityPersonne>();
        }
    }
}
