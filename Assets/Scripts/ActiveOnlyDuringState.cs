using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum GameStates
{
    MainMenu , Gameplay , Waiting , Lose , Credits 
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
