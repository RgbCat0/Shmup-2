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
        private Transform fireTransform;
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
                    if (bulletPrefab)
                        Shoot();
                    yield return new WaitForSeconds(fireRate);
                }
                yield return null;
            }
        }

        private void Shoot() // added for player upgrades to shoot multiple bullets
        {
            for (var i = 0; i < fireTransform.childCount; i++)
            {
                Instantiate(
                    bulletPrefab,
                    fireTransform.GetChild(i).position,
                    fireTransform.GetChild(i).rotation
                );
            }
        }

        private void SpecialAttack() // kills all enemies on screen
        {
            var parent = GameObject.Find("WaveParent");
            for (var i = 0; i < parent.transform.childCount; i++)
            {
                parent.transform.GetChild(i).GetComponent<BaseEnemy>().Die();
            }
        }
    }
}
