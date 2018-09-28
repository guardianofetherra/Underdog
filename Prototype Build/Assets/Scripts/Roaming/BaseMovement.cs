using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseMovement : MonoBehaviour {

    public Joystick MainControls;

    public Vector3 PlayerPos;

    public float MoveSpeed;

    private Rigidbody Player;

	// Use this for initialization
	void Start () {
        Player = this.GetComponent<Rigidbody>();
        PlayerPos = this.GetComponent<Transform>().position;
	}
	
	// Update is called once per frame
	void Update () {
		if(MainControls.Horizontal() < 0)
        {
            Player.AddForce(Vector3.left * MoveSpeed);
        }
        else if(MainControls.Horizontal() > 0)
        {
            Player.AddForce(Vector3.right * MoveSpeed);
        }

        if (MainControls.Vertical() < 0)
        {
            Player.AddForce(Vector3.back * MoveSpeed);
        }
        else if (MainControls.Vertical() > 0)
        {
            Player.AddForce(Vector3.forward * MoveSpeed);
        }
    }
}
