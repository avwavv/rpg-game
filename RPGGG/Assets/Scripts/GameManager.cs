using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private playerHealth playerHealth;
    [SerializeField] private GameObject endScreen;
    [SerializeField] private TMP_Text endText;
    [SerializeField] private Button button;

    private void Start()
    {
        endScreen.SetActive(false);
        endText.text = "";
    }

    public void Restart()
    {
        SceneManager.LoadScene(sceneName: SceneManager.GetActiveScene().name);
    }
    

    public void WinScreen()
    {
        endScreen.SetActive(true);
        button.enabled = true;
        endText.text = "You won!";
    }

    public void DeathScreen()
    {
        endScreen.SetActive(true);
        button.enabled = true;
        endText.text = "You've lost";
    }

    private void OnEnable()
    {
        GameEvents.Death += DeathScreen;
        GameEvents.Win += WinScreen;
    }

    private void OnDisable()
    {
        GameEvents.Death -= DeathScreen;
        GameEvents.Win -= WinScreen;
    }
}
