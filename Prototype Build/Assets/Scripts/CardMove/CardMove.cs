using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardMove : MonoBehaviour {
    private GameObject Region;
    public float speed = 5f;
    private Vector3 pos;
    
	// Use this for initialization
	void Start () {
        Region = GameObject.Find("UsedDeck");
        pos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Region.GetComponent<UsedDeckRegion>().inRegion == false)
        {
            transform.Translate(speed * 2, -speed, 0);
        }
        else if (Region.GetComponent<UsedDeckRegion>().inRegion == true)
        {
            transform.Translate(0, 0, 0);
            gameObject.transform.position = pos;
            gameObject.SetActive(false);
            Region.GetComponent<UsedDeckRegion>().inRegion = false;
        }
    }
}
