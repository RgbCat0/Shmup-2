using UnityEngine;
using _Scripts;

public class Bomb : MonoBehaviour
{
    public float animationTime = 0;
    public Vector2 startPos;
    public Vector2 endPos;
    public bool isExploding;

    private void OnEnable()
    {
        startPos = transform.position;
    }

    private void Update()
    {
        transform.position = Vector2.Lerp(startPos, endPos, animationTime);
        if (isExploding)
        {
            Kaboom();
            isExploding = false;
        }
    }

    private void Kaboom()
    {
        var parent = GameObject.Find("WaveParent");
        for (var i = 0; i < parent.transform.childCount; i++)
        {
            parent.transform.GetChild(i).GetComponent<BaseEnemy>().Die();
        }
    }
}
