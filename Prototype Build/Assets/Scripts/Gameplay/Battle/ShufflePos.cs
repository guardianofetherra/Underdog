using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShufflePos : MonoBehaviour {

    public Transform PlayerHand;

    private void Start()
    {
        PlayerHand = this.transform;
    }

    public void Shuffle()
    {
        foreach(Transform Child in PlayerHand)
        {
            int RandomPos;
            RandomPos = Random.Range(0, PlayerHand.childCount);
            
                Child.SetSiblingIndex(RandomPos);
        }
    }
}
