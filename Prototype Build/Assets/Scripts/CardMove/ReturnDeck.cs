using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnDeck : MonoBehaviour {
    private GameObject DeckRegion;
    private GameObject EndTurn;
    private GameObject Enemy;
    public GameObject EnemyTurn;
    public float speed = 5f;
    private Vector3 pos;
    private GameObject counter;

    // Use this for initialization
    void Start()
    {
        DeckRegion = GameObject.Find("Deck");
        EndTurn = GameObject.Find("Switch");
        counter = GameObject.Find("TurnCounter");
        Enemy = GameObject.Find("EnemyModel");
        gameObject.SetActive(false);
        pos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (DeckRegion.GetComponent<DeckRegion>().inDeckRegion == false && EndTurn.GetComponent<SwitchtoDeck>().endTurn == true)
        {
            gameObject.SetActive(true);
            transform.Translate(-speed * 2, 0, 0);
        }
        else if (DeckRegion.GetComponent<DeckRegion>().inDeckRegion == true && EndTurn.GetComponent<SwitchtoDeck>().endTurn == true)
        {
            transform.Translate(0, 0, 0);
            gameObject.SetActive(false);
            gameObject.transform.position = pos;
            DeckRegion.GetComponent<DeckRegion>().inDeckRegion = false;
            counter.GetComponent<TurnCounter>().nextTurn = true;
            EndTurn.GetComponent<SwitchtoDeck>().endTurn = false;
            Enemy.GetComponent<EnemyAttack>().Attacked = false;
            EnemyTurn.SetActive(false);
        }
    }
}
