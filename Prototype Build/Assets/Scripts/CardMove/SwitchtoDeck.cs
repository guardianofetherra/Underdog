using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchtoDeck : MonoBehaviour
{
    public bool endTurn = false;
    public GameObject EnemyTurn;
    public GameObject ball;

    private void Start()
    {
        EnemyTurn.SetActive(false);
    }

    public void TurnEnded()
    {
        endTurn = true;
        ball.SetActive(true);
        EnemyTurn.SetActive(true);
    }
}
