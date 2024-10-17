using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class PlayerShooting : MonoBehaviour
    {
        private PlayerControls _playerControls;
        private InputAction _shoot;

        private bool _isShooting;

        [SerializeField]
        private GameObject bulletPrefab;

        //bullet speed will be handled in the bullet script / prefab
        [SerializeField]
        private float fireRate = 0.5f;

        [SerializeField]
        public Vector2 spawnOffset;
        public bool canShoot = true;

        private void Start()
        {
            Player.Instance.PlayerControls.Player.Shoot.performed += _ => _isShooting = true;
            Player.Instance.PlayerControls.Player.Shoot.canceled += _ => _isShooting = false;
            StartCoroutine(ShootLoop());
        }

        private IEnumerator ShootLoop()
        {
            while (true)
            {
                if (_isShooting && canShoot)
                {
                    if (bulletPrefab) // for testing purposes
                        Instantiate(bulletPrefab, transform.position, Quaternion.identity);
                    yield return new WaitForSeconds(fireRate);
                }
                yield return null;
            }
        }
    }
}
