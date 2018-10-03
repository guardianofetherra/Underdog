using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaCounter : MonoBehaviour
{

    public Text staminaText;
    public int stamina;

    public Transform SelectionArea;

    public void StaminaDecrease()
    {
        stamina -= (SelectionArea.GetChild(0).GetComponent<CardDisplay>().card.staminaCost);
        //enemyHealth -= 2;
        if (stamina >= 0)
        {
            staminaText.text = stamina.ToString();
        }
        else
        {
            stamina = 0;
            staminaText.text = stamina.ToString();
        }
    }

}
