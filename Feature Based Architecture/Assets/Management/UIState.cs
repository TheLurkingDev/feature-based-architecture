using UnityEngine;

namespace TheLurkingDev.Managers
{
    public class UIState : MonoBehaviour, IManager
    {
        public IManager GetManager<T>()
        {
            return this;
        }

        private Canvas mainCanvas;
        private UIStates currentUIState;

        private void Start()
        {
            mainCanvas = GameObject.Find("MainCanvas").GetComponent<Canvas>();
            currentUIState = UIStates.StartMenu;
            DontDestroyOnLoad(this);
        }

        private void SetUIControlReferencesForState(UIStates uiState)
        {
            switch (uiState)
            {
                case UIStates.StartMenu:
                    GetStartMenuControls();
                    break;
                case UIStates.Playing:
                    break;
                case UIStates.PausedMenu:
                    break;
                default:
                    break;
            }
        }

        private void GetStartMenuControls()
        {

        }
    }

    public enum UIStates
    {
        StartMenu = 0,
        Playing = 1,
        PausedMenu = 2
    }
}