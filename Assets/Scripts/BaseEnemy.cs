using UnityEngine;

public class BaseEnemy : MonoBehaviour
{
    [SerializeField]
    protected int health;

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
            Destroy(gameObject);
    }
}
