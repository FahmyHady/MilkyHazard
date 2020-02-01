using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Flags]
public enum GameStates
{
    MainMenu = 0x0, Gameplay = 0x1, Waiting = 0x2, Lose = 0x3, Credits = 0x4
}
public class ActiveOnlyDuringState : MonoBehaviour
{
    public GameStates activeState;

    public void CheckState(GameStates newState)
    {
        if (newState == activeState)
        {
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
