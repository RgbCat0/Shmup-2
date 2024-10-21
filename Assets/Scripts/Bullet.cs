using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private bool _setup;

    [SerializeField]
    private float speed = 10f;

    [SerializeField]
    private float destroyTime;

    // private void Setup(float eulerAngleZ)
    // {
    //     transform.rotation = Quaternion.Euler(0, 0, eulerAngleZ);
    //     _setup = true;
    // }
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
        transform.Translate(transform.up * (Time.deltaTime * speed));
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (CompareTag("PlayerBullet") && other.CompareTag("Enemy"))
        {
            print("player bullet hit enemy");
            other.GetComponent<BaseEnemy>().TakeDamage(1);

            Destroy(gameObject);
        }
        else if (CompareTag("EnemyBullet") && other.CompareTag("Player"))
        {
            // other.GetComponent<Player>().TakeDamage(1);
            Destroy(gameObject);
            throw new NotImplementedException("Player TakeDamage method not implemented");
        }
    }
}
