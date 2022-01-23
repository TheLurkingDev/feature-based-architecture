using System.Collections.Generic;
using System.Linq;

namespace TheLurkingDev.Managers
{
    // INHERITANCE
    public class GameManager : Manager
    {
        //public static GameManager Instance { get; private set; }
        private List<IManager> managers = new List<IManager>();
        private void Awake()
        {
            EstablishSingleton();
        }

        private void Start()
        {
            managers = GetComponents<IManager>().ToList();            
            //var sceneManager = managers.Find(m => m.GetManager<SceneState>() != null);
        }

        // POLYMORPHISM
        public override IManager GetManager<T>()
        {
            return managers.Find(m => m.GetManager<T>() != null);
        }
    }    
}
