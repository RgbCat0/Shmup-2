using UnityEngine;

namespace Player
{
    public class Player : MonoBehaviour
    {
        public static Player Instance;
        public PlayerControls PlayerControls;

        [SerializeField]
        private int health = 3;
        public int Health
        {
            get => health;
            set
            {
                health = value;
                if (health <= 0)
                    GameManager.Instance.GameOver();
            }
        }

        private void Awake()
        {
            InstanceManager();
            PlayerControls = new PlayerControls();
            PlayerControls.Enable();
        }

        private void InstanceManager()
        {
            if (Instance == null)
                Instance = this;
            else
                Destroy(gameObject);
        }
    }
}
