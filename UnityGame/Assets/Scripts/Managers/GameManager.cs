using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{

    public Transform player; // Useful for player position for all other scripts

    public int health = 6;
    public TextMeshProUGUI healthTxt;
    public int score = 0;
    public TextMeshProUGUI scoreTxt;
    public int xp = 0;

    public int enemyCount = 0; // Useful for the amount of enemies currently in game for all other scripts

    public GameState State; 
    public static event Action<GameState> stateChanging;


    private void Start()
    {
        State = GameState.Playing; 
    }

    private void Update()
    {
        //Updates current health and score
        healthTxt.text = "Health: " + health.ToString();
        scoreTxt.text = "Score: " + score.ToString();

        //Pause and Resume Game with Esc
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            if (State == GameState.Paused)
                ResumeGame();
            else
                changeState(GameState.Paused);//PauseGame
        }

        if(health < 1)
            changeState(GameState.Lost);
        
    }
  
    public void ResumeGame()
    {
        changeState(GameState.Playing);
    }

    public void changeState(GameState state)
    {
        if(state == State) return;
        stateChanging?.Invoke(state);
        State = state;
    }
    [Serializable]
    public enum GameState { Playing, Paused, Levelling, Won, Lost}

}
