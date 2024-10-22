using System.Collections;
using UnityEngine;

public class BaseEnemy : MonoBehaviour
{
    [SerializeField]
    private protected int hitPoints;

    [SerializeField]
    private protected float speed;
    public bool enemyBehavior;
    private int _powerUpChance;

    public void TakeDamage(int damage)
    {
        hitPoints -= damage;
        if (hitPoints <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        if (Random.Range(0, 100) < _powerUpChance)
        {
            // spawn powerup
        }
        Destroy(gameObject);
    }

    public IEnumerator SetupEnemy(Enemy enemy)
    {
        hitPoints = enemy.hitPoints;
        speed = 1 + (float)WaveSystem.Instance.currentWave / 4;
        transform.rotation = Quaternion.Euler(0, 0, 180); // face down
        var t = 0f;
        var startPos = transform.position;
        while (t < 1)
        {
            t += Time.deltaTime / enemy.timeToStart;
            transform.position = Vector2.Lerp(startPos, enemy.moveTowards, t);
            yield return null;
        }
        enemyBehavior = true;
    }
}
