using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PisteManageri : MonoBehaviour {

    public static PisteManageri instanssi;
    public int pisteet; //pisteet muuttuja
    public int huippuPisteet;

	void Awake () 
    {
        if (instanssi == null) // tarkistetaan, että instasseja on vain yksi Awake funktion sisällä
            {
                instanssi = this;
            }
	}

    void Start()
    {
        pisteet = 0;
        PlayerPrefs.SetInt("piste", pisteet);
    }

    void Update () 
    {
		
	}

    public void LisaaPisteet() // pisteiden lisäyksen funktio
    {
        pisteet += 1; // + 1 piste
    }

    public void LopetaPisteet() // julkinen lopetusfunktio, johon lisätään pisteiden tallennus
    {
        PlayerPrefs.SetInt("piste", pisteet);
        //print(pisteet);
        if (PlayerPrefs.HasKey("huippuPisteet"))
        {
            if(pisteet > PlayerPrefs.GetInt("huippuPisteet")) // jos pelaajaa sai enemmän kuin oma ennätys
            {
                PlayerPrefs.SetInt("huippuPisteet", pisteet); // asetetaan saadut pisteet huippupisteisiin
            }
        }
        else {
            PlayerPrefs.SetInt("huippuPisteet", pisteet);
        }
    }
}
