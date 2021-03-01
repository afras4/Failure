using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Botones : MonoBehaviour
{
    public DeathObject[] deathObject;
    public int colorButton;
    public GameObject funcion;
    public GameObject button1;
    public GameObject button2;
    public GameObject button3;
    public GameObject button4;
    public AudioSource pressButton;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    //botonblanco
    private void OnCollisionEnter2D(Collision2D other) {
        if(colorButton == 1){
        if(other.gameObject.tag == "Player1"){
            pressButton.Play();
            funcion.GetComponent<Boton> ().spawn();
            deathObject[0].color = 0;
            deathObject[1].color = 0;
            deathObject[2].color = 0;
            deathObject[3].color = 0;

            button1.gameObject.SetActive(false);
            button2.gameObject.SetActive(false);
            button3.gameObject.SetActive(false);
            button4.gameObject.SetActive(false);

        }    
        }
        if(colorButton == 2){
        if(other.gameObject.tag == "Player2"){
            pressButton.Play();
            funcion.GetComponent<Boton> ().spawn();
            deathObject[0].color = 0;
            deathObject[1].color = 0;
            deathObject[2].color = 0;
            deathObject[3].color = 0; 

            button1.gameObject.SetActive(false);
            button2.gameObject.SetActive(false);
            button3.gameObject.SetActive(false);
            button4.gameObject.SetActive(false);
        }
        }
    
    }
}
