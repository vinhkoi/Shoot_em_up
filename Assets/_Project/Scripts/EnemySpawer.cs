using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

namespace Shmup
{
    public class EnemySpawer : MonoBehaviour
    {
        [SerializeField] List<EnemyType> enemyTypes;
        [SerializeField] int maxEnemies = 10;
        [SerializeField] float spawnInterval = 2f;

        [SerializeField] SplineContainer spline1; 
        [SerializeField] SplineContainer spline2; 

        List<SplineContainer> splines;
        EnemyFactory enemyFactory;

        float spawnTimer;
        int enemiesSpawned;

        void OnValidate ()
        {
            splines = new List<SplineContainer> (GetComponentsInChildren<SplineContainer>());
        }

        void Start ()
        {
            enemyFactory = new EnemyFactory ();
            /*splines = new List<SplineContainer>(FindObjectsOfType<SplineContainer>()); // Lấy danh sách spline từ tất cả các đối tượng trong Scene*/
/*            SpawnEnemy(spline1);
            SpawnEnemy(spline2);*/
            SpawnInitialEnemies(); // Hàm này sẽ spawn enemy lần đầu tiên khi Scene bắt đầu
        }

        void Update ()
        {
            spawnTimer += Time.deltaTime;

            if(enemiesSpawned <  maxEnemies && spawnTimer >= spawnInterval)
            {
                /*SpawnEnemy(spline);*/
                SpawnEnemy(spline1);
                SpawnEnemy(spline2);
                spawnTimer = 0f;
            }
        }

        void SpawnInitialEnemies()
        {
            foreach (var spline in splines)
            {
                SpawnEnemy(spline);
            }
        }

        void SpawnEnemy(SplineContainer splineContainer)
        {

            if (enemyTypes.Count == 0 || splineContainer == null)
            {
                Debug.LogWarning("Missing enemy types or splines for spawning.");
                return;
            }

            EnemyType enemyType = enemyTypes[UnityEngine.Random.Range(0, enemyTypes.Count)];
            /*SplineContainer spline = splines[UnityEngine.Random.Range(0, splines.Count)];*/


            //GameObject enemy = enemyFactory.CreateEnemy(enemyType, spline);
            enemyFactory.CreateEnemy(enemyType, splineContainer);

            enemiesSpawned++;
        }



    }
}
