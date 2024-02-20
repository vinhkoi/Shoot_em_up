using Eflatun.SceneReference;
using UnityEngine;
using UnityEngine.UI;
using Utilities;

namespace Shmup
{
        public class MainMenuUi : MonoBehaviour
        {
            [SerializeField] SceneReference startingLevel;
            [SerializeField] SceneReference settingScene;
            [SerializeField] Button playButton;
            [SerializeField] Button quitButton;
            [SerializeField] Button settingButton;

        private void Awake()
            {
                playButton.onClick.AddListener(() => Loader.Load(startingLevel));
                quitButton.onClick.AddListener(() => Helpers.Quitgame());
                settingButton.onClick.AddListener(() => Loader.Load(settingScene));
                Time.timeScale = 1f;
            }
        }
      
}
