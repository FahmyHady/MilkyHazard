using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
public class GameStarted : UnityEvent<GameStates>
{ }
public class GameManager : MonoBehaviour
{
    [SerializeField] ActiveOnlyDuringState[] UIStates;
    public GameStarted GameStarted;
    static GameManager instance;
    private GameStates currentState;
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameManager>();
            }

            return instance;
        }
    }
    public GameStates CurrentState
    {
        get => currentState;
        set
        {
            currentState = value;
            GameStarted.Invoke(currentState);
        }
    }
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        for (int i = 0; i < UIStates.Length; i++)
        {
            GameStarted.AddListener(UIStates[i].CheckState);
        }
        currentState = GameStates.MainMenu;
    }
    public void StartTheGame()
    {
        currentState = GameStates.Gameplay;
    }
    public void RestartTheGame()
    {
        SceneManager.LoadScene(0);
    }
    public void CreditsScreen()
    {
        currentState = GameStates.Credits;
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
