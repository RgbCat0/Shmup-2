using System.Collections;
using UnityEngine;

namespace _Scripts
{
    public class ShootingEnemy : BaseEnemy
    {
        private Transform _player;
        private float _timeToShoot = 1f;

        [SerializeField]
        private GameObject bulletPrefab;

        [SerializeField]
        private Transform fireTransform;

        private void Start()
        {
            _player = GameObject.FindWithTag("Player").transform;
            StartCoroutine(ShootLoop());
            _timeToShoot = 1 + (float)WaveSystem.Instance.currentWave / 4;
        }

        private IEnumerator ShootLoop()
        {
            while (true)
            {
                {
                    if (enemyBehavior)
                        if (bulletPrefab)
                            Shoot();
                    yield return new WaitForSeconds(_timeToShoot);
                }
                yield return null;
            }
        }

        private void Shoot()
        {
            var playerDirection = _player.position - transform.position;
            for (var i = 0; i < fireTransform.childCount; i++)
            {
                Instantiate(
                    bulletPrefab,
                    fireTransform.GetChild(i).position,
                    ToPlayer
                        ? fireTransform.GetChild(i).rotation
                        : Quaternion.Euler(0, 0, Vector2.SignedAngle(Vector2.up, playerDirection))
                );
            }
        }
    }
}
