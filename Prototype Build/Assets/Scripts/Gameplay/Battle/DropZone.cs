using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IPointerEnterHandler, IDropHandler, IPointerExitHandler
{
    private Interactable CardData;
    public bool IsDeckArea;

    public Transform HPCounter;
    public int enemyHealth;
    public Text healthText;
    int DamageData;

    public Transform StaminaCounter;
    public int playerStamina;
    public Text staminaText;
    int StaminaData;

    public GameObject Ball;

    void Start()
    {
        Ball.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        //Debug.Log("Something Entered");

        //Debug.Log(this.transform.childCount);

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //Debug.Log("Something Exited");
    }

    public void OnDrop(PointerEventData eventData)
    {
        CardData = eventData.pointerDrag.GetComponent<Interactable>();
        if (CardData != null)
        {
            if (IsDeckArea == false)
            {
                if (CardData.GetComponent<CardDisplay>().card.staminaCost < playerStamina)
                {
                    CardData.OrgParent = this.transform;
                    //Puts card at the far right of the dropzone
                    CardData.transform.SetAsLastSibling();

                    Debug.Log(CardData.name + " Was Used");

                    StaminaData = CardData.GetComponent<CardDisplay>().card.staminaCost;
                    StaminaDecrease(StaminaData);

                    DamageData = CardData.GetComponent<CardDisplay>().card.attack;
                    HealthDecrease(DamageData);

                    Ball.SetActive(true);
                }
                else
                {
                    CardData.transform.SetSiblingIndex(CardData.PlaceHoldPos.GetSiblingIndex());
                }
            }
            else if (IsDeckArea == true)
            {
                //Needs
                //Return it to original position before it was placed in the other dropzone
                CardData.transform.SetSiblingIndex(CardData.PlaceHoldPos.GetSiblingIndex());
                //CardData.transform.SetSiblingIndex(CardData.PlaceHolder.transform.GetSiblingIndex());

                Debug.Log(CardData.name + " Was Not Used");
            }
            //CardData.OrgParent = this.transform;
        }
    }

    public void HealthDecrease(int Damage)
    {
        enemyHealth -= Damage;
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

    public void StaminaDecrease(int Stamina)
    {
        playerStamina -= StaminaData;
        //enemyHealth -= 2;
        if (playerStamina >= 0)
        {
            staminaText.text = playerStamina.ToString();
        }
        else
        {
            playerStamina = 0;
            staminaText.text = playerStamina.ToString();
        }
    }

    public void LateUpdate()
    {
        if (IsDeckArea == false)
        {
            if (this.transform.childCount > 0)
            {
                Debug.Log("Somethings Here");
                foreach (Transform Child in this.transform)
                {
                    Child.gameObject.SetActive(false);
                }
            }
        }
    }
}
