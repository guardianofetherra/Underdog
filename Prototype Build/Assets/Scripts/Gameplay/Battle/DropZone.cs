using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IPointerEnterHandler, IDropHandler, IPointerExitHandler
{
    private Interactable CardData;
    public bool IsDeckArea;

    /*
    public Transform HPCounter;
    public int enemyHealth;
    public Text healthText;
    int DamageData;

    public Transform StaminaCounter;
    public int playerStamina;
    public Text staminaText;
    int StaminaData;
    */
    public GameObject HPCounter;
    private HealthCounter HP;
    int DamageData;
    public GameObject StaminaCounter;
    private StaminaCounter Stamina;
    int StaminaData;

    public SwitchtoDeck Trigger;
    public GameObject Ball;

    public delegate void DropDelegate();
    public static event DropDelegate OnDropEvent;

    void Start()
    {
        HP = HPCounter.GetComponent<HealthCounter>();
        Stamina = StaminaCounter.GetComponent<StaminaCounter>();
        Ball.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        //Debug.Log("Something Entered");
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
                if (CardData.GetComponent<CardDisplay>().card.staminaCost <= Stamina.currentStamina && Trigger.endTurn == false)
                {
                    CardData.OrgParent = this.transform;
                    //Puts card at the far right of the dropzone
                    CardData.transform.SetAsLastSibling();

                    Debug.Log(CardData.name + " Was Used");

                    StaminaData = CardData.GetComponent<CardDisplay>().card.staminaCost;
                    Stamina.StaminaDecrease(StaminaData);

                    DamageData = CardData.GetComponent<CardDisplay>().card.attack;
                    HP.HealthDecrease(DamageData);

                    Ball.SetActive(true);

                    if(OnDropEvent != null)
                    {
                        OnDropEvent();
                    }
                }
                else
                {
                    CardData.transform.SetSiblingIndex(CardData.PlaceHoldPos.GetSiblingIndex());
                }
            }
            else if (IsDeckArea == true)
            {
                //Return it to original position before it was placed in the other dropzone
                CardData.transform.SetSiblingIndex(CardData.PlaceHoldPos.GetSiblingIndex());

                Debug.Log(CardData.name + " Was Not Used");
            }
        }
    }

    public void Update()
    {
        if (IsDeckArea == false)
        {
            if (this.transform.childCount > 0)
            {
                Debug.Log("Somethings Here");
                foreach (Transform Child in this.transform)
                {

                    CardData.transform.SetParent(CardData.PlaceHolder.transform.parent);
                    Destroy(CardData.PlaceHolder);
                    CardData.gameObject.SetActive(false);
                }
            }
        }
    }
    
    public void Reset()
    {
        if(IsDeckArea == true)
        {
            foreach(Transform Child in this.transform)
            {
                Child.gameObject.SetActive(true);
            }
        }
    }
}
