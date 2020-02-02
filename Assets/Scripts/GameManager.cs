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
    [SerializeField] Text objectsPutOnFireText;
    [SerializeField] Text animalsSavedText;
    [SerializeField] Text requiredAnimalsSavedText;
    [SerializeField] Text requiredObjectsPutOnFireText;
    [SerializeField] Image liveImage;
    [SerializeField] GameObject livesParent;
    public int objectsPutOffFireNumber;
    public int animalsSavedNumber;
    [SerializeField] int requiredAnimalsToSaveNumber;
    [SerializeField] int requiredObjectsToPutOffFireNumber;
    [SerializeField] int lives;
    public GameStarted GameStartedEvent = new GameStarted();
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
            GameStartedEvent.Invoke(currentState);
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
            GameStartedEvent.AddListener(UIStates[i].CheckState);
        }
        CurrentState = GameStates.MainMenu;
        for (int i = 0; i < lives; i++)
        {
            Instantiate(liveImage, livesParent.transform);
        }
        requiredObjectsPutOnFireText.text = "/" + requiredObjectsToPutOffFireNumber.ToString();
        requiredAnimalsSavedText.text = "/" + requiredAnimalsToSaveNumber.ToString();
    }
    private void Update()
    {
        objectsPutOnFireText.text = objectsPutOffFireNumber.ToString();
        animalsSavedText.text = animalsSavedNumber.ToString();
    }
    public void StartTheGame()
    {
        CurrentState = GameStates.Gameplay;
    }
    public void RestartTheGame()
    {
        SceneManager.LoadScene(0);
    }
    public void CreditsScreen()
    {
        CurrentState = GameStates.Credits;
    }
    public void MainMenuScreen()
    {
        CurrentState = GameStates.MainMenu;
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void GetHit()
    {
        lives--;
        if (lives == 0)
        {
            StartCoroutine(Die());
        }

    }
    IEnumerator Die()
    {
        CurrentState = GameStates.Waiting;
        yield return new WaitForSeconds(1);
        CurrentState = GameStates.Lose;
    }
}
