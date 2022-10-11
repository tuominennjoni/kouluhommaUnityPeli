using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laajentaja : MonoBehaviour {

    public GameObject alusta; // julkinen GameObject alustalle
    public GameObject timantti; // julkinen GameObject timantille
    public bool peliLoppu; // booleani pelin loppumiselle
    Vector3 viimeinenSijainti; // viimeisimmän alustan sijainti
    float koko; // alustan koko

	void Start () 
    {
        viimeinenSijainti = alusta.transform.position;
        koko = alusta.transform.localScale.x; 

        for (int i = 0; i < 4; i++) // kutsutaan satunnaisfunktio 4 kertaa
            AlustaSiirtymat();
	}
	
	void Update () 
    {
        if (PeliManageri.instanssi.peliLoppu == true)
        {
            CancelInvoke("AlustaSiirtymat");
        }
	}
    
    public void AloitaAlustojenKopiointi()
    {
        InvokeRepeating("AlustaSiirtymat", 2f, 0.2f); // luodaan uusia alustan palasia
    }

    void AlustaSiirtymat() // satunnaisfunktio, jolla arvotaan kumpaa siirtymä funktiota käytetään 
    {
        if(peliLoppu)
        {
            return;
        }
        int satu = Random.Range(0, 6);
        if (satu < 3)
        {
            SiirtymaX();
        }
        else if (satu >= 3)
        {
            SiirtymaZ(); 
        }
    }

    void SiirtymaX() // alustaa laajennetaan X - suuntaan
    {
        Vector3 sij = viimeinenSijainti;
        sij.x += koko;
        Instantiate(alusta, sij, Quaternion.identity);
        viimeinenSijainti = sij;

        int sat = Random.Range(0, 4);
        if (sat < 1)
        {
            Instantiate(timantti, new Vector3(sij.x, sij.y + 1.0f, sij.z), timantti.transform.rotation); // lisätään satunnaisesti esiintyvät timantit molempiin funktioihin X ja Z
        }
    }

    void SiirtymaZ() // alustaa laajennetaan Z - suuntaan
    {
        Vector3 sij = viimeinenSijainti;
        sij.z += koko;
        Instantiate(alusta, sij, Quaternion.identity);
        viimeinenSijainti = sij;

        int sat = Random.Range(0, 4);
        if (sat < 1)
        {
            Instantiate(timantti, new Vector3(sij.x, sij.y + 1.0f, sij.z), timantti.transform.rotation); // lisätään satunnaisesti esiintyvät timantit molempiin funktioihin X ja Z
        }
            
    }
}
