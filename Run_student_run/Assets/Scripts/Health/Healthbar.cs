using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    [SerializeField] private Health playerHealth;
    [SerializeField] private Image totalheartbar;
    [SerializeField] private Image currenthealtBar;

    private void Start()
    {
        totalheartbar.fillAmount = playerHealth.currentHealth / 10;
    }

    private void Update()
    {
        currenthealtBar.fillAmount = playerHealth.currentHealth / 10;
    }
}
