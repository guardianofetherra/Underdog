using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsedDeckRegion : MonoBehaviour {
    public bool inRegion;

    void Start()
    {
        inRegion = false;
    }

    void OnTriggerEnter (Collider other)
    {
        if(other.gameObject.CompareTag("Indicator1"))
        {
            inRegion = true;
            Debug.Log("Detected");
        }
	}
}
