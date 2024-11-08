using System;
using UnityEngine;
using _Scripts.PlayerSpace;

namespace _Scripts
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField]
        private float speed = 10f;

        [SerializeField]
        private float destroyTime;

        private void Start()
        {
            if (destroyTime == 0)
            {
                gameObject.SetActive(false);
                var e = new Exception("Destroy time not set");
            }
            Destroy(gameObject, 2f);
        }

        private void Update()
        {
            transform.position += transform.up * (Time.deltaTime * speed);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (CompareTag("PlayerBullet") && other.CompareTag("Enemy"))
            {
                other.GetComponent<BaseEnemy>().TakeDamage(1);
                Destroy(gameObject);
            }
            else if (CompareTag("EnemyBullet") && other.CompareTag("Player"))
            {
                other.GetComponent<Player>().TakeDamage(1);
                Destroy(gameObject);
                // throw new NotImplementedException("Player TakeDamage method not implemented");
            }
        }
    }
}
