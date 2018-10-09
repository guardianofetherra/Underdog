using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthCounter : MonoBehaviour
{

    public int enemyHealth;
    public Text healthText;
    int DamageData;
    public bool isDamage = false;

    public void Start()
    {
        healthText.text = enemyHealth.ToString();
    }

    public void HealthDecrease(int Damage)
    {
        enemyHealth -= Damage;
        isDamage = true;
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

    public void HealthIncrease()
    {
        enemyHealth += 2;
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
