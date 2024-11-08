using UnityEngine;

namespace _Scripts
{
    public class MovingEnemy : BaseEnemy
    {
        [SerializeField]
        private float rotationSpeed = 2f;

        [SerializeField]
        private float returnHeight;

        private Transform _player;

        [SerializeField]
        private bool _returnToStart;

        private void Start()
        {
            _player = GameObject.FindWithTag("Player").transform;
            if (Random.Range(0, 2) == 0 && !ToPlayer) // chooses between going left or right
            {
                speed *= -1;
                transform.Rotate(0, 0, 180);
            }
        }

        public void Update()
        {
            if (!enemyBehavior)
                return;
            if (!ToPlayer)
                MoveLeftRight();
            else
                MoveToPlayer();
        }

        // left or right movement
        private void MoveLeftRight()
        {
            transform.rotation = Quaternion.Euler(0, 0, speed > 0 ? 90 : -90); // not the prettiest solution
            transform.position += Vector3.right * (Time.deltaTime * speed);
        }

        private void MoveToPlayer()
        {
            //rotates towards the player
            Vector2 player = _player.position;
            var direction = player - (Vector2)transform.position;

            if (transform.position.y < player.y)
                _returnToStart = true;
            if (transform.position.y > returnHeight)
                _returnToStart = false;
            if (_returnToStart)
                direction = new Vector2(0, returnHeight) - (Vector2)transform.position;

            var angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
            var rotation = Quaternion.AngleAxis(angle, Vector3.back);
            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                rotation,
                Time.deltaTime * rotationSpeed
            );
            transform.position += transform.up * (Time.deltaTime * speed);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                other.GetComponent<PlayerSpace.Player>().TakeDamage(1);
                Destroy(gameObject);
            }
        }
    }
}
