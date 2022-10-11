using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggeriTarkastaja : MonoBehaviour {

	void Start () {
		
	}
	
	void Update () {
		
	}

    void OnTriggerExit(Collider jotain) // kutsutaan Triggerin poistumisfunktiota
    {
        if (jotain.gameObject.tag == "pallo") // tarkistetaan peliobjekti tagillä "pallo"
            {
                Invoke("Putoaminen", 1f); // jos näin käy, niin kutsutaan Putoaminen-funktio ja käytetään Invokea, jotta saadaan viive mukaan
            }
    }

    void Putoaminen() // putoamis funktio
    {
        GetComponentInParent<Rigidbody>().useGravity = true; // painovoima true
        GetComponentInParent<Rigidbody>().isKinematic = false; // alustat eivät putoile itsekseen
        Destroy(transform.parent.gameObject, 2.0f);
    }
}
