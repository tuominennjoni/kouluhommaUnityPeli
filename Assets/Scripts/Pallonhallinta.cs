using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pallonhallinta : MonoBehaviour {

    public GameObject partikkeli; // effekti partikkeli jota lentää kun pelaaja osuu timanttiin ja se hajoaa

    [SerializeField]
    private float nopeus; // nopeus
    [SerializeField]
    bool alku; // peli alkaa kun pelaaja klikkaa hiirtä
    bool loppu; // kun pallo tippuu alustalta niin boolean loppu muuttuu todeksi
    Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

	void Start () 
    {
        alku = false; // pelin alku asetettu falselle
        loppu = false; // samoin loppu
	}
	
	void Update () 
    {
        if (!alku)
        {
            if (Input.GetMouseButtonDown(0)) // jos hiirtä klikataan
            {
                rb.velocity = new Vector3(nopeus, 0, 0); // pallon liike x suuntaan
                alku = true;

                PeliManageri.instanssi.AloitaPeli(); // vertaillaan onko hiirtä painettu, jos on niin peli alkaa
            }
        }

        if (!Physics.Raycast(transform.position, Vector3.down, 1.0f))  
        {
            loppu = true;
            rb.velocity = new Vector3(0, -25f, 0); // pallon putoamisnopesu
            Destroy(gameObject, 1.0f);

            Camera.main.GetComponent<KameraSeuranta>().peliLoppu = true; // komento ettei kamera seuraa kun pallo tippuu alustalta

            PeliManageri.instanssi.LopetaPeli(); // PeliManageri kontroloi pelin loppumisen
        }

        if (Input.GetMouseButtonDown(0) && !loppu) 
        {
            Suunnanvaihto();
            PisteManageri.instanssi.LisaaPisteet(); 
        }
	}

    void Suunnanvaihto()
    {
        if (rb.velocity.z > 0)
        {
            rb.velocity = new Vector3(nopeus, 0, 0);
        }
        else if (rb.velocity.x > 0) 
        {
            rb.velocity = new Vector3(0, 0, nopeus);
        }
    }

    void OnTriggerEnter(Collider jotain) // funktio, jolla tuhotaan peliobjekti jos silla on sama tägi kuin timantilla
    {
        if (jotain.gameObject.tag == "timantti") // tarkistetaan peliobjekti tagillä "timantti" 
        {
            GameObject osa = Instantiate(partikkeli, jotain.gameObject.transform.position, Quaternion.identity); // luodaan partikkeli kun timantti tuhoutuu
            Destroy(jotain.gameObject);
            Destroy(osa, 1.0f);                      
        }
    }
}
