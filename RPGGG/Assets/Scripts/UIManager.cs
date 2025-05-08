using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Image health, mana;
    [SerializeField] private Slider exp;
    [SerializeField] private playerHealth _playerHealth;
    [SerializeField] private TMP_Text levelText;

    public void UpdateLevelText(int level)
    {
        levelText.text = level.ToString();
    }

    private void Update()
    {
        health.fillAmount = Mathf.Lerp( health.fillAmount, _playerHealth.GetHealthRatio(), 2 * Time.deltaTime);
    }

    public void UpdateXpSlider(float xpRatio)
    {
        exp.value = xpRatio;
    }
}
