using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

public class BaseEnemy : MonoBehaviour
{
    public int hitPoints;
    public bool enemyBehavior;

    private void Start()
    {
        StartCoroutine(MoveToStart(new Vector2(0, 0), 2f));
    }

    public void TakeDamage(int damage)
    {
        hitPoints -= damage;
        if (hitPoints <= 0)
            Destroy(gameObject);
    }

    public IEnumerator MoveToStart(Vector2 startPosition, float time)
    {
        var t = 0f;
        var startPos = transform.position;
        while (t < 1)
        {
            t += Time.deltaTime / time;
            transform.position = Vector2.Lerp(startPos, startPosition, t);
            yield return null;
        }
        enemyBehavior = true;
    }
}
