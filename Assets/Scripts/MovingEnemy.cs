using UnityEngine;

public class MovingEnemy : BaseEnemy
{
    [SerializeField]
    private float rotationSpeed = 2f;

    public bool moveToPlayer;
    private Transform _player;

    private void Start()
    {
        _player = GameObject.FindWithTag("Player").transform;
        if (Random.Range(0, 2) == 0 && !moveToPlayer) // chooses between going left or right
        {
            speed *= -1;
            transform.Rotate(0, 0, 180);
        }
    }

    public void Update()
    {
        if (!enemyBehavior)
            return;
        if (!moveToPlayer)
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
            other.GetComponent<Player.Player>().TakeDamage(1);
            Destroy(gameObject);
        }
    }
}
