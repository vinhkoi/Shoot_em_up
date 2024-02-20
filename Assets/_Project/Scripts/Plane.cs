using UnityEngine;

namespace Shmup
{
    public abstract class Plane : MonoBehaviour
    {
        [SerializeField] int maxHealth;
        int health;
        public AudioManager audioManager;
        protected virtual void Awake() 
        {
            health = maxHealth;
            audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        }

        public void SetMaxHealth(int amount)
        {
            health = amount;
        }

        public void TakeDamage(int amount)
        {
            health -= amount;
            if(health <= 0)
            {
                Die();
            }
        }

        public void AddHealth(int amount)
        {
            health+= amount;
            if(health > maxHealth)
            {
                health = maxHealth;
            }
        }

        public float GetHealthNormalized()
        {
            return health /(float) maxHealth;
        }

        protected abstract void Die();

    }
}
