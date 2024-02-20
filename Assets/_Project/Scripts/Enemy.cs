using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

namespace Shmup
{
    public class Enemy : Plane
    {
        [SerializeField] GameObject explosionPrefab;
        /*internal object OnSystemDestroyed;*/
        protected override void Die()
        {
            GameManager.Instance.AddScore(10);
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            OnSystemDestroyed?.Invoke();
            Destroy(gameObject);
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                audioManager.playSFX(audioManager.explosion);
                Destroy(gameObject);
                collision.gameObject.GetComponent<Player>().TakeDamage(10);
            }
        }
        public UnityEvent OnSystemDestroyed;
    }
}
