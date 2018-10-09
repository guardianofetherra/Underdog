using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModelFeedback : MonoBehaviour {

    private GameObject EnemyModel;
    private GameObject PlayerModel;

    public GameObject Enemy;
    public GameObject Player;

    private bool cardData;

    private Rigidbody E_rb;
    private Rigidbody P_rb;

    private Renderer P_rdr;
    private Renderer E_rdr;

    public Image Selection;
    public int JumpHeight;
    public bool isJump = false;
    public bool PlayerAttack = false;

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
        EnemyModel = GameObject.FindGameObjectWithTag("EnemyModel");
        PlayerModel = GameObject.FindGameObjectWithTag("PlayerModel");

        P_rb = PlayerModel.GetComponent<Rigidbody>();                     
        E_rb = EnemyModel.GetComponent<Rigidbody>();

        P_rdr = PlayerModel.GetComponent<Renderer>();
        E_rdr = EnemyModel.GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {
        EnemyMove();
	}

    void OnCardDrop()
    {
        Invoke("PlayerMove", 0.1f);
        PlayerAttack = Enemy.GetComponent<HealthCounter>().isDamage;
    }

    void PlayerMove()
    {
        if(isJump == true)
        {
            P_rb.AddForce(Vector3.up * JumpHeight);
            Debug.Log("isJump");
            isJump = false;
            if(PlayerAttack == true)
            {
                E_rdr.material.SetColor("_Color",Color.blue);
                Debug.Log("Enemy Damaged");
                PlayerAttack = false;
            }
        }
    }

    void EnemyMove()
    {
        //E_rb.AddForce(Vector3.up * JumpHeight * Time.deltaTime);
    }
}
