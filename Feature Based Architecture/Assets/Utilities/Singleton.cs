using UnityEngine;

namespace TheLurkingDev.Utilities
{
    public abstract class MonoSingleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        public static T Instance { get; private set; }

        protected virtual void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this as T;
        }

        protected virtual void OnApplicationQuit()
        {
            Instance = null;
            Destroy(gameObject);
        }
    }

    public abstract class PersistentMonoSingleton<T> : MonoSingleton<T> where T : MonoBehaviour
    {
        protected override void Awake()
        {
            DontDestroyOnLoad(gameObject);
            base.Awake();
        }
    }

    public abstract class Singleton<T> where T : new()
    {
        public static T Instance { get; private set; }

        public Singleton()
        {
            if (Instance != null)
                return;

            Instance = new T();
        }
    }
}
