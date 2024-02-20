using UnityEngine;
using UnityEngine.Splines;

namespace Shmup
{
    public class EnemyFactory 
    {
        public GameObject CreateEnemy (EnemyType enemytype, SplineContainer spline)
        {
            if (enemytype == null || enemytype.enemyPrefab == null || spline == null)
            {
                Debug.LogWarning("Missing enemy prefab or spline for enemy creation.");
                return null;
            }


            EnemyBuilder builder = new EnemyBuilder()
                .SetBasePrefab(enemytype.enemyPrefab)
                .SetSpline(spline)
                .SetSpeed(enemytype.speed);

            return builder.Build();
        }

    }
}
