using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public enum GameState
    {
        Undefined,
        MainMenu,
        InGame,
        GameOver
    }

    public GameState gameState;

    private void Awake()
    {
        if (SceneManager.GetActiveScene().name != "MainMenu" && Instance == null)
        {
            SceneManager.LoadScene("MainMenu");
            return;
        }
        InstanceManager();
    }

    private void InstanceManager()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
            gameState = GameState.MainMenu;
        }
        else
            Destroy(gameObject);
    }

    #region MainMenu
    public void StartGame()
    {
        gameState = GameState.InGame;
        SceneManager.LoadScene("Main");
    }
    #endregion
}