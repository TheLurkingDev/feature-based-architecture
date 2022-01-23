using UnityEngine;

namespace TheLurkingDev.Managers
{
    // ABSTRACTION
    public abstract class Manager : MonoBehaviour, IManager
    {
        public static Manager Instance { get; private set; }
                
        public virtual IManager GetManager<T>()
        {
            return this;
        }

        protected void EstablishSingleton()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
            }
            else
            {
                Instance = this;
                DontDestroyOnLoad(this);
            }
        }
    }
}