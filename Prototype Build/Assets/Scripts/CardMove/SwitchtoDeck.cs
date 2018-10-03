using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchtoDeck : MonoBehaviour
{
    public bool endTurn = false;
    public GameObject ball;
   
    public void TurnEnded()
    {
        endTurn = true;
        ball.SetActive(true);
    }
}
