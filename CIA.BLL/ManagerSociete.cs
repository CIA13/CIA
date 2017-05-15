using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIA.BLL
{
    /// <summary>
    /// Implémente un pattern singleton threadsafe avec double check
    /// </summary>
    public class ManagerSociete
    {
        private static readonly object _myLock = new object();
        private static volatile ManagerSociete _instance;

        private ManagerSociete()
        {

        }

        public static ManagerSociete Instance
        {
            get
            {
                if(_instance == null)
                {
                    lock(_myLock)
                    {
                        if (_instance == null) _instance = new ManagerSociete();
                    }
                }

                return _instance;
            }
        }
    }
}
