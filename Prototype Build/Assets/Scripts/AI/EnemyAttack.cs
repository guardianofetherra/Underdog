using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyAttack : MonoBehaviour
{
    private GameObject Player;
    private GameObject Trigger;
    public bool Attacked;

    void Start()
    {
        Player = GameObject.Find("PlayerModel");
        Trigger = GameObject.Find("Switch");
        Attacked = false;
    }

    void Update()
    {
        if(Attacked == false && Trigger.GetComponent<SwitchtoDeck>().endTurn == true)
        {
            Player.GetComponent<PlayerHealth>().playerHealth -= 4;
            Attacked = true;
        }
    }
}
