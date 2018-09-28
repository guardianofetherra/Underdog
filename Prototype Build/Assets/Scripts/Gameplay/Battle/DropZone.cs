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
                //Puts card at the far right of the dropzone
                CardData.transform.SetAsLastSibling();

                Debug.Log(CardData.name + " Was Used");

                DamageData = CardData.GetComponent<CardDisplay>().card.attack;
                HealthDecrease(DamageData);
                
            }
            else if (IsDeckArea == true)
            {
                //Needs
                //Return it to original position before it was placed in the other dropzone
                CardData.transform.SetSiblingIndex(CardData.PlaceHoldPos.GetSiblingIndex());
                //CardData.transform.SetSiblingIndex(CardData.PlaceHolder.transform.GetSiblingIndex());

                Debug.Log(CardData.name + " Was Not Used");
            }
            CardData.OrgParent = this.transform;
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

    public void LateUpdate()
    {
        if(IsDeckArea == false)
        {
            if(this.transform.childCount > 0)
            {
                Debug.Log("Somethings Here");
                foreach(Transform Child in this.transform)
                {
                    Child.gameObject.SetActive(false);
                }
            }
        }
    }
}
