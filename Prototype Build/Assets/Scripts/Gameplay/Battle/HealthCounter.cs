using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthCounter : MonoBehaviour {

    public Text healthText;
    public int enemyHealth;

    public Transform SelectionArea;

    public void HealthDecrease()
    {
        enemyHealth -= (SelectionArea.GetChild(0).GetComponent<CardDisplay>().card.attack);
        //enemyHealth -= 2;
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
