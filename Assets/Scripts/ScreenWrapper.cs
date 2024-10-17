using UnityEngine;

public class ScreenWrapper : MonoBehaviour
{
    private float _screenLeft,
        _screenRight;

    [SerializeField]
    private float leftOffset,
        rightOffset;

    private void Start()
    {
        var cam = Camera.main;
        if (cam == null)
            return;
        _screenLeft = cam.ScreenToWorldPoint(new Vector3(0, 0, 0)).x;
        _screenRight = cam.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x;
    }

    private void Update() => CheckBounds();

    private void CheckBounds()
    {
        if (transform.position.x > _screenRight + rightOffset)
            transform.position = new Vector2(_screenLeft, transform.position.y);
        else if (transform.position.x < _screenLeft - leftOffset)
            transform.position = new Vector2(_screenRight, transform.position.y);
    }
}
