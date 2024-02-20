using System;
using UnityEngine;
namespace Shmup
{
    public class Player : Plane
    {

        [SerializeField] float maxFuel;
        [SerializeField] float fuelConsumptionRate;
        //public GameObject defaultBulletPrefab; // Đạn mặc định
        //private GameObject currentBulletPrefab; // Đạn hiện tại

        float fuel;

        void Start()
        {
            fuel = maxFuel;
            //currentBulletPrefab = defaultBulletPrefab;
        }
        public float GetFuelNormalized()
        {
            return fuel / maxFuel;
        }
        void Update()
        {
            fuel -= fuelConsumptionRate * Time.deltaTime;
        }

        public void AddFuel(int amount)
        {
            fuel += amount;
            if(fuel > maxFuel)
            {
                fuel = maxFuel;
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                Destroy(collision.gameObject);
            }
        }

        protected override void Die()
        {
            // TODO
        }

        internal void AddFuel(float amount)
        {
            throw new NotImplementedException();
        }
    }
}
