using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnInvisible : MonoBehaviour
{
    private GameObject Trigger;
    public float Timer;

    void Start()
    {
        Trigger = GameObject.Find("Switch");
        gameObject.SetActive(true);
        Timer = 30.0f;
    }

    // Update is called once per frame
    void Update ()
    {
		if(Trigger.GetComponent<SwitchtoDeck>().endTurn == true)
        {
            gameObject.SetActive(false);
        }
        else if(Timer <= 0.0f)
        {
            gameObject.SetActive(false);
        }

        Countdown();
    }

    void Countdown()
    {
        if(gameObject.activeSelf == true)
        {
            Timer--;
        }
        else
        {
            Timer = 30.0f;
        }
    }
}
