using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace TheLurkingDev.Managers
{
    public class SceneState : MonoBehaviour, IManager
    {
        public UnityEvent<GameScenes, GameScenes> OnSceneChange;        
        public GameScenes GameScene { get; private set; }

        private void Start()
        {
            //OnSceneChange = new UnityEvent<GameScenes, GameScenes>();
            //GameScene = GameScenes.NotDefined;
            //ChangeScene(GameScenes.Start);
            DontDestroyOnLoad(this);
        }

        public void ChangeScene(GameScenes gameScene)
        {
            OnSceneChange.Invoke(GameScene, gameScene);
                        
            SceneManager.LoadScene((int)gameScene);
        }

        public IManager GetManager<T>()
        {
            return this;
        }
    }

    public enum GameScenes
    {
        NotDefined = -1,
        Start = 0,
        Main = 1
    }
}
