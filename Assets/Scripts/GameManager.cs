using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
   public static GameManager Instance;
    private State state;
    public event EventHandler OnGameStart;
    public event EventHandler OnGamePlaying;
    public event EventHandler OnGameOver;
    private void Awake()
    {
        Instance = this;
        state = State.GameStart;

    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case State.GameStart:
                OnGameStart?.Invoke(this, new EventArgs());
                break;
            case State.GamePlaying:
                OnGamePlaying?.Invoke(this, new EventArgs());
                break;
            case State.GameOver:
                OnGameOver?.Invoke(this, new EventArgs());
                break;
        }
    }
    public bool IsGamePlaying()
    {
        return state == State.GamePlaying;
    }
    public void SetGameState(State stateGame)
    {
        state = stateGame;
    }
    public void GamePlay()
    {
        state = State.GamePlaying;
    }
}
public enum State
{
    GameStart,
    GamePlaying,
    GameOver
}