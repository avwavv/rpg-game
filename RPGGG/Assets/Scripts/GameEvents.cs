using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public delegate void OnGameEvents();

    public static OnGameEvents Death;
    public static OnGameEvents Win;

    public static void CallGameEnd()
    {
        if (Death != null)
        {
            Death();
        }
    }

    public static void CallGameWin()
    {
        if (Win != null)
        {
            Win();
        }
    }

}
