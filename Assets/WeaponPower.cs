using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shmup
{
    public class WeaponPower : Item
    {
        public GameObject newBulletPrefab;
        void OnTriggerEnter(Collider other)
        {
            if (other != null)
            {
                Player player = other.GetComponent<Player>();
                if (player != null)
                

                    // Hủy đối tượng power-up
                    Destroy(gameObject);
            }
            else
            {
                Debug.LogError("Collider 'other' is null!");
            }

        }
    }
}
