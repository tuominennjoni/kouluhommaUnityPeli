using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KameraSeuranta : MonoBehaviour {

    public GameObject pallo; // peliobjekti Pallo
    Vector3 offset; 
    public float tarinaVaihe; // tahti miten kamera vaihtaa "paikkaa" kun seuraa
    public bool peliLoppu; // boolean pelin loppumisesta

	void Start () 
    {
        offset = pallo.transform.position - transform.position;
        peliLoppu = false; // peli ei ole loppunut
	}
	
	void Update () 
    {
        if (!peliLoppu) // jos peli ei ole loppunut
        {
            Seurata(); // niin seurataan palloa
        }
	}

    void Seurata() // funktio kameran seurannalle
    {
        Vector3 paikka = transform.position; // nykyinen kameran paikka
        Vector3 tavoitePaikka = pallo.transform.position - offset; // etäisyys palloon
        paikka = Vector3.Lerp(paikka, tavoitePaikka, tarinaVaihe * Time.deltaTime); // tahti miten kamera vaihtaa paikkaa kun seuraa
        transform.position = paikka;
    }
}
