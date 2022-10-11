using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeliManageri : MonoBehaviour {

    public static PeliManageri instanssi;
    public bool peliLoppu; // booleani pelin lopulle

    void Awake()
    {
        if (instanssi == null) // tarkistetaan että instansseja on vain yksi Awake funktiossa
        {
            instanssi = this;
        }
    }
	void Start () 
    {
        peliLoppu = false; // pelin loppu false;		 
	}
	
	void Update () 
    {
		
	}

    public void AloitaPeli() // pelin aloittamisen funktio
    {
        UIManageri.instanssi.PelinAlku();
        GameObject.Find("Laajentaja").GetComponent<Laajentaja>().AloitaAlustojenKopiointi(); // aloitetaan uusien alustojen tuottaminen kun peli alkaa
    }

    public void LopetaPeli() // pelin loppumisen funktio
    {
        UIManageri.instanssi.PelinLoppu(); 
        PisteManageri.instanssi.LopetaPisteet(); // pisteiden tuleminen loppuu
        peliLoppu = true; // asetetaan pelin loppuminen trueksi
    }

    public void SuljePeli() // koko pelin sulkemisen funktio
    {
        Application.Quit();
    }
}

