using UnityEngine;
using UnityEngine.Serialization;

public class MovingEnemy : BaseEnemy
{
    [SerializeField]
    private float speed = 2f,
        rotationSpeed = 2f;

    [SerializeField]
    private bool leftRightMovement;

    private void Start()
    {
        if (Random.Range(0, 2) == 0 && !leftRightMovement) // chooses between going left or right
        {
            speed *= -1;
            transform.Rotate(0, 0, 180);
        }
    }

    public void Update()
    {
        if (!leftRightMovement)
            MovementType1();
        else
            MovementType2();
    }

    // left or right movement
    private void MovementType1()
    {
        transform.position += Vector3.right * (Time.deltaTime * speed);
    }

    private void MovementType2()
    {
        //rotates towards the player
        Vector2 player = PlayerMovement.Instance.transform.position;
        var direction = player - (Vector2)transform.position;

        var angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
        var rotation = Quaternion.AngleAxis(angle, Vector3.back);
        transform.rotation = Quaternion.Slerp(
            transform.rotation,
            rotation,
            Time.deltaTime * rotationSpeed
        );
        transform.position += transform.up * (Time.deltaTime * speed);

        // transform.SetPositionAndRotation(movement, transform.rotation);
    }
}
