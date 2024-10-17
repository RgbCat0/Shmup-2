using UnityEngine;

namespace Player
{
    public class Player : MonoBehaviour
    {
        public static Player Instance;
        public PlayerControls PlayerControls;

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
