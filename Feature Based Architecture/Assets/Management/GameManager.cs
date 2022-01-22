using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace TheLurkingDev.Managers
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }
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

        public IManager GetManager<T>()
        {
            return managers.Find(m => m.GetManager<T>() != null);
        }

        private void EstablishSingleton()
        {
            if(Instance != null && Instance != this)
            {                
                Destroy(gameObject);
            }
            else
            {                
                Instance = this;
            }
        }
    }    
}
