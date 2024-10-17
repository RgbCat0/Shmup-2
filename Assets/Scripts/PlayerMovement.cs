using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement Instance;
    private PlayerControls _playerControls;
    private InputAction _move;

    [SerializeField]
    private Vector2 direction;

    [SerializeField]
    private float speed = 5f;

    private void Awake() => InstanceManager();

    private void Start()
    {
        _playerControls = new PlayerControls();
        _playerControls.Enable();
        _move = _playerControls.Player.Movement;
        _move.performed += ctx => direction = ctx.ReadValue<Vector2>();
        _move.canceled += _ => direction = Vector2.zero;
    }

    private void InstanceManager()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void Update()
    {
        transform.Translate(direction * (Time.deltaTime * speed));
    }
}
