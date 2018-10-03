using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModelFeedback : MonoBehaviour {

    private GameObject Enemy;
    private GameObject Player;
    private bool cardData;
    private Rigidbody E_rb;
    private Rigidbody P_rb;

    public Image Selection;
    public int JumpHeight;

    private void OnEnable()
    {
        DropZone.OnDropEvent += OnCardDrop;
    }

    private void OnDisable()
    {
        DropZone.OnDropEvent -= OnCardDrop;
    }

    // Use this for initialization
    void Start () {
        Enemy = GameObject.FindGameObjectWithTag("EnemyModel");
        Player = GameObject.FindGameObjectWithTag("PlayerModel");

        P_rb = Player.GetComponent<Rigidbody>();
        E_rb = Enemy.GetComponent<Rigidbody>();

        
	}
	
	// Update is called once per frame
	void Update () {
        EnemyMove();
	}

    void OnCardDrop()
    {
        Invoke("PlayerMove", 0.1f);
    }

    void PlayerMove()
    {
        if(Selection.GetComponent<Image>().transform.childCount > 0)
        {
            P_rb.AddForce(Vector3.up * JumpHeight);
            Debug.Log("isJump");
        }
    }

    void EnemyMove()
    {
        //E_rb.AddForce(Vector3.up * JumpHeight * Time.deltaTime);
    }
}
