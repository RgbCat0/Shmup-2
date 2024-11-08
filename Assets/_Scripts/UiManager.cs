using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

namespace _Scripts
{
    public class UiManager : MonoBehaviour
    {
        public static UiManager Instance;

        [SerializeField]
        private InputAction pause;
        private bool _isPaused;

        public bool specialAtkReady;

        [SerializeField]
        private GameObject specialAtkObj,
            pauseGameObject;

        [SerializeField]
        private TextMeshProUGUI scoreText;

        [SerializeField]
        private List<GameObject> lives;

        private void Awake()
        {
            if (Instance == null)
                Instance = this;
            else
                Destroy(gameObject);
        }

        private void Start()
        {
            pause = PlayerSpace.Player.Instance.PlayerControls.Player.pause;
            pause.performed += _ => PauseGame();
            StartCoroutine(SpecialAtk());
        }

        private IEnumerator SpecialAtk()
        {
            while (true)
            {
                if (!specialAtkReady)
                {
                    specialAtkObj.SetActive(false);
                    yield return null;
                }
                else
                {
                    specialAtkObj.SetActive(true);
                    yield return new WaitForSeconds(1f);
                    specialAtkObj.SetActive(false);
                    yield return new WaitForSeconds(1f);
                }
            }
        }

        public void ScoreCounter(int score)
        {
            scoreText.text = score.ToString();
        }

        public void UpdateLives(int _lives)
        {
            for (var i = 0; i < lives.Count; i++)
            {
                lives[i].SetActive(i < _lives);
            }
        }

        private void PauseGame()
        {
            if (!_isPaused)
            {
                pauseGameObject.SetActive(true);
                Time.timeScale = 0;
                _isPaused = true;
                return;
            }
            pauseGameObject.SetActive(false);
            Time.timeScale = 1;
            _isPaused = false;
        }
    }
}
