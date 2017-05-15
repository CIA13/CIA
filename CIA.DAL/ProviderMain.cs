using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CIA.DAL
{
    /// La possibilité d'attaquer le dataContext avec la méthode générique Set<T> permet de partager
    /// et réutiliser les méthodes très réccurentes en CRUD.
    /// Il suffit de dériver de ProviderMain en spécifiant T comme on peut le voir dans ProviderPersonne ou ProviderSociete
    public abstract class ProviderMain<T> where T : class, new()
    {
        public T GetEntityByPK(int PK)
        {
            T result = default(T);

            try
            {
                using (CiaContext dataContext = new CiaContext())
                {                    
                    result = dataContext.Set<T>().Find(PK);
                }
            }

            catch
            {
                throw;
            }

            return result;
        }

        /// <summary>
        /// Avec l'utilisation des lambdas, on évite d'écrire X méthodes pour X conditions différentes
        /// On utilise à la place un prédicat.
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public T GetEntityByPredicateFirst(Expression<Func<T, bool>> predicate)
        {
            T result = default(T);

            try
            {
                using (CiaContext dataContext = new CiaContext())
                {                    
                    result = dataContext.Set<T>().FirstOrDefault(predicate);                    
                }
            }

            catch
            {
                throw;
            }

            return result;
        }

        public List<T> GetEntitiesByPredicateWhere(Expression<Func<T, bool>> predicate)
        {
            List<T> result = new List<T>();

            try
            {
                using (CiaContext dataContext = new CiaContext())
                {
                    result = dataContext.Set<T>().Where(predicate).ToList();
                }
            }

            catch
            {
                throw;
            }

            return result;
        }

        public void Create(T myObject)
        {
            if (myObject == null) throw new ArgumentNullException(nameof(myObject));

            try
            {
                using (CiaContext dataContext = new CiaContext())
                {
                    dataContext.Set<T>().Add(myObject);
                    dataContext.SaveChanges();
                }
            }

            catch
            {
                throw;
            }

            
        }
    }
}
