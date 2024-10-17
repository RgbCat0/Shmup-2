using UnityEngine;

public class BackgroundMover : MonoBehaviour
{
    [SerializeField]
    private float speed = 1f,
        resetPosition = -10.8f;

    void Update()
    {
        transform.position += Vector3.down * (Time.deltaTime * speed);
        if (transform.position.y <= resetPosition)
            transform.position = new Vector3(0, 0, transform.position.z);
    }
}
