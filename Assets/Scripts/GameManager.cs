using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public enum GameState
{
    Playing,
    Menu,
    GameOver,
}

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameState currentState;
    public int currentScore = 0;
    public int highestScore;
    [SerializeField] private GameObject menuUI;
    [SerializeField] private GameObject gameOverUI;
    [SerializeField] private GameObject gameplayUI;
    public void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        SetState(GameState.Menu);
    }
    public void Update()
    {
        
    }
    public void SetState(GameState newState)
    {
        currentState = newState;
        HandleStateChanged(currentState);
    }
    public void HandleStateChanged(GameState state)
    {
        switch (state)
        {
            case GameState.Playing:
                menuUI.SetActive(false);
                gameplayUI.SetActive(true);
                gameOverUI.SetActive(false);
                break;
            case GameState.Menu:
                gameplayUI.SetActive(false);
                menuUI.SetActive(true);
                gameOverUI.SetActive(false);
                break;
            case GameState.GameOver:
                gameOverUI.SetActive(true);
                gameplayUI.SetActive(false);
                break;
        }
    }
    public void StartGame()
    {
        SetState(GameState.Playing);
        currentScore = 0;
    }
    public void GameOver()
    {
        SetState(GameState.GameOver);
    }
    public void RestartGame()
    {
        SetState(GameState.Menu);
    }
    public void AddScore()
    {
        currentScore++;
    }
}
