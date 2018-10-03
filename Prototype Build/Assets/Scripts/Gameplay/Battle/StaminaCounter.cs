using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaCounter : MonoBehaviour
{

    public int playerStamina;
    [HideInInspector] public int currentStamina;
    public Text staminaText;
    int StaminaData;

    public void Start()
    {
        currentStamina = playerStamina;
        staminaText.text = currentStamina.ToString();
    }

    public void StaminaDecrease(int Stamina)
    {
        currentStamina -= Stamina;
        //enemyHealth -= 2;
        if (playerStamina >= 0)
        {
            staminaText.text = currentStamina.ToString();
        }
        else
        {
            playerStamina = 0;
            staminaText.text = currentStamina.ToString();
        }
    }

    public void Replenish()
    {
        currentStamina = playerStamina;
        staminaText.text = currentStamina.ToString();
    }

}
