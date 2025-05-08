using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Image health, mana;
    [SerializeField] private Slider exp;
    [SerializeField] private playerHealth _playerHealth;

    private void Update()
    {
        health.fillAmount = Mathf.Lerp(_playerHealth.GetHealthRatio(), health.fillAmount, 2 * Time.deltaTime);
    }
}
