using Eflatun.SceneReference;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

namespace Shmup
{
    public class GameManager :MonoBehaviour
    {     
        [SerializeField] SceneReference mainMenuScene;
        [SerializeField] GameObject gameOverUi;
        public static GameManager Instance { get; private set; }
        public Player Player => player;
        public GameObject bossPrefab;
        private bool bossActivated = false;
        public GameObject bossObject;

        bool bossSpawned = false;
        Player player;
        Boss boss;
        int score;
        float restartTime = 3f;
        public bool IsGameOver()
        {
            return player.GetHealthNormalized() <= 0 || player.GetFuelNormalized() <= 0;
        }

        void Awake()
        {
            Instance = this;

            player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

        }
        void Update()
        {
            if (IsGameOver())
            {
                restartTime -= Time.deltaTime;
                if(gameOverUi.activeSelf == false)
                {
                    gameOverUi.SetActive(true);
                }

                if(restartTime <= 0)
                {
                    Loader.Load(mainMenuScene);
                }
            }

            if(score >= 700 && !bossSpawned)
            {

                bossObject.SetActive(true);
                bossActivated = true;
            }
        }
        public void AddScore(int amount)
        {
            score += amount;
        }

        public int GetScore() { return score; }

    }
}
