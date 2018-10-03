using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthCounter : MonoBehaviour
{

    public int enemyHealth;
    public Text healthText;
    int DamageData;

    public void Start()
    {
        healthText.text = enemyHealth.ToString();
    }

    public void HealthDecrease(int Damage)
    {
        enemyHealth -= Damage;
        if (enemyHealth >= 0)
        {
            healthText.text = enemyHealth.ToString();
        }
        else
        {
            enemyHealth = 0;
            healthText.text = enemyHealth.ToString();
        }
    }

}
