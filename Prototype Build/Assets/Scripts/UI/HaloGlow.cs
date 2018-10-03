using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HaloGlow : MonoBehaviour {

    public Behaviour Halo;
	// Use this for initialization
	void Start () {
        Halo = (Behaviour)GetComponent("Halo");
        Halo.enabled = false;
	}

    IEnumerator DeckGlow()
    {
        for (float f = 1f; f >= 0.05f; f -= 0.05f)
        {
            Halo.enabled = true;
            yield return new WaitForSeconds(.05f);
        }
        for (float f = 1f; f <= 1f; f += 0.05f)
        {
            Halo.enabled = false;
            yield return new WaitForSeconds(1f);
        }
    }

    public void Glow()
    {
        StartCoroutine("DeckGlow");
    }
}
