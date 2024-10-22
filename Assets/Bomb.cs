using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float animationTime = 0;
    public Vector2 startPos;
    public Vector2 endPos;

    private void OnEnable()
    {
        startPos = transform.position;
    }

    private void Update()
    {
        transform.position = Vector2.Lerp(startPos, endPos, animationTime);
    }
}
