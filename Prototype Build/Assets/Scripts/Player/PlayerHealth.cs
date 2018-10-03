using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public Text healthText;
    public int playerHealth;

    void Start()
    {
        playerHealth = 20;
    }

    void Update()
    {
        if(playerHealth <= 0)
        {
            SceneManager.LoadScene("GameOverScene");
        }

        healthText.text = playerHealth.ToString();
    }
}
