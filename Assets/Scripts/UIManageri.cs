using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManageri : MonoBehaviour {

    public static UIManageri instanssi;

    public GameObject TulosPaneeli;
    public GameObject peliLoppuPaneeli;
    public Text pisteet;
    public Text huippuPisteet1; 
    public Text huippuPisteet2; 
    public GameObject aloitusTeksti;

    void Awake()
    {
        if (instanssi == null) // varmistetaan että instasseja on vain yksi Awaken funktiossa
            {
                instanssi = this; 
            }
    }
	void Start () 
    {
        huippuPisteet1.text = "Huippupisteet " + PlayerPrefs.GetInt("huippuPisteet"); // huippupisteiden tallennus
    }
	
	void Update () 
    {
		
	}

    public void PelinAlku()
    {
        aloitusTeksti.SetActive(false);
        TulosPaneeli.GetComponent<Animator>().Play("paneeliylos");
    }

    public void PelinLoppu()
    {
        pisteet.text = PlayerPrefs.GetInt("piste").ToString();
        huippuPisteet2.text = PlayerPrefs.GetInt("huippuPisteet").ToString();
        peliLoppuPaneeli.SetActive(true);
    }

    public void AloitaAlusta() // alota alusta funktio
    {
        SceneManager.LoadScene(0); 
    }
}
