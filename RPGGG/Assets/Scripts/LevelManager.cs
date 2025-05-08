using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelManager : MonoBehaviour
{
    private int currentXP;
    private int currentLevel = 1;
    public static LevelManager instance;
    public UnityEvent <int> levelGained;
    public UnityEvent <float> xpGained;

    private void Awake()
    {
        instance = this;
    }

    public void GiveXP(int xpToGive)
    {
        currentXP += xpToGive;
        CalculateLevel();
    }

    public void CalculateLevel()
    {
        int xpToNextLevel = currentLevel * 50;
        xpGained.Invoke((float)currentXP / (float)xpToNextLevel);
        if (currentXP >= xpToNextLevel)
        {
            currentLevel += 1;
            currentXP -= xpToNextLevel;
            levelGained.Invoke(currentLevel);
            CalculateLevel();
        }
    }
    
    
}
