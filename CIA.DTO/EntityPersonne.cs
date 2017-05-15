using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIA.DTO
{
    public class EntityPersonne
    {
        /// <summary>
        /// Clé primaire.
        /// 3 possibilités de nommage pour le moteur EntityFramework:
        /// ID
        /// NomDeClasse + ID: EntityPersonneID
        /// Nom personnalisé, dans ce cas à préceder de l'attribut [Key] pour que la propriété soit identifiée en tant que PK
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Nom de la Personne avec exemple d'utilisation des DataAnnotations
        /// </summary>
        [Required(ErrorMessage ="Le nom est requis")]
        [MinLength(length:3, ErrorMessage ="Le nom est trop court")]
        [MaxLength(length:30, ErrorMessage ="Le nom est trop long.")]
        public string Nom { get; set; }
        /// <summary>
        /// Prénom de la personne
        /// </summary>
        public string Prenom { get; set; }
        /// <summary>
        /// Age de la personne
        /// </summary>
        public int Age { get; set; }

        ///// <summary>
        ///// FK de la societe où travaille l'employé
        ///// </summary>
        //public int SocieteID { get; set; }    
        /// <summary>
        /// Objet Employeur dont dépend l'employé: N --> 1
        /// </summary>
        public EntitySociete Employeur { get; set; }   
    }
}
