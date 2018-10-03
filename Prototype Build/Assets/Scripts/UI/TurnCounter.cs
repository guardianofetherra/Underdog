using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnCounter : MonoBehaviour {

    private Text turn;
    private int counter;
    public bool nextTurn = true;

	// Use this for initialization
	void Start () {
        turn = this.GetComponent<Text>();
        counter = 1;
        turn.text = "Round " + counter;
	}
	
	// Update is called once per frame
	void Update () {
	}

    public void EndRound()
    {
        if(nextTurn == true)
        {
            counter++;
            turn.text = "Round " + counter;
            nextTurn = false;
        }
    }
}
