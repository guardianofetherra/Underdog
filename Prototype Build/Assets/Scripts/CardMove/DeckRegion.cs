using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckRegion : MonoBehaviour
{
    public bool inDeckRegion;

    void Start()
    {
        inDeckRegion = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Indicator2"))
        {
            inDeckRegion = true;
            Debug.Log("Detected");
        }
    }
}
