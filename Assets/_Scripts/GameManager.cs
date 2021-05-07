using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum GameState { GAME, PAUSE };
    public GameState gameState { get; private set; }
    public GameState lastState { get; private set; }
    public int points;
       
    public delegate void ChangeStateDelegate();
    public static ChangeStateDelegate changeStateDelegate;

    private static GameManager _instance;

    
    private GameManager()
    {
        points = 0;
        gameState = GameState.GAME;
    }


    public static GameManager GetInstance()
   {
       if(_instance == null)
       {
           _instance = new GameManager();
       }

       return _instance;
   }

   public void ChangeState(GameState nextState)
    {
        lastState = gameState;
        gameState = nextState;
        changeStateDelegate();
    }

    private void Reset()
    {
        points = 0;
    }
}
