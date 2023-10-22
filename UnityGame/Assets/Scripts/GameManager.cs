using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Transform player; // Useful for player position for all other scripts

    public int health = 6;
    public Text healthTxt;
    public int score = 0;
    public Text scoreTxt;
    public int xp = 0;

    public int enemyCount = 0; // Useful for the amount of enemies currently in game for all other scripts

    public bool isPaused = false;
    public GameObject pauseMenu;
    public Button Continue;
    public Button Quit;

    public bool isLevelling = false;
    public GameObject levelMenu;
    public Button option1;
    public Button option2;
    public Button option3;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        ResumeGame(); 
    }

    private void Update()
    {
        //Updates current health and score
        healthTxt.text = "Health: " + health.ToString();
        scoreTxt.text = "Score: " + score.ToString();

        //Pause and Resume Game with Esc
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            if (isPaused)
                ResumeGame();
            else
                PauseGame();
        }
        Continue.onClick.AddListener(ResumeGame);
        Quit.onClick.AddListener(QuitGame);

        /*if(xp >= 50)
        {
            xp = 0;
            LevelUp();
            
        }*/
    }

    private void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1; //Resume the games
        pauseMenu.SetActive(false); //Turns off the pause menu
    }

    private void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0; //Pause the game
        pauseMenu.SetActive(true); //Turns on the pause menu
    }

    private void QuitGame()
    {
        Application.Quit();
    }

    private void LevelUp()
    {
        isLevelling = true;
        Time.timeScale = 0; // Pauses the game
        levelMenu.SetActive(true);
    }

}
