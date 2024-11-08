using UnityEngine;
using UnityEngine.InputSystem;

namespace _Scripts.PlayerSpace
{
    public class PlayerMovement : MonoBehaviour
    {
        private InputAction _move;

        [SerializeField]
        private Vector2 direction;

        [SerializeField]
        private float speed = 5f;

        private void Start()
        {
            _move = Player.Instance.PlayerControls.Player.Movement;
            _move.performed += ctx => direction = ctx.ReadValue<Vector2>();
            _move.canceled += _ => direction = Vector2.zero;
        }

        private void Update()
        {
            transform.Translate(direction * (Time.deltaTime * speed));
        }
    }
}
