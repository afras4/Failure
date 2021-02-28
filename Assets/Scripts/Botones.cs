using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Botones : MonoBehaviour
{
    public DeathObject[] deathObject;
    public int colorButton;
    public GameObject funcion;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D other) {
        if(colorButton == 1){
        if(other.gameObject.tag == "Player1"){
            deathObject[0].color = 1;
            deathObject[1].color = 1;
            deathObject[2].color = 1;
            deathObject[3].color = 1;
            funcion.GetComponent<Boton> ().spawn();
            this.gameObject.SetActive(false);
            
        }    
        }
        if(colorButton == 2){
        if(other.gameObject.tag == "Player2"){
            deathObject[0].color = 2;
            deathObject[1].color = 2;
            deathObject[2].color = 2;
            deathObject[3].color = 2;
            funcion.GetComponent<Boton> ().spawn();
            this.gameObject.SetActive(false);
              
        }
        }
    
    }
}
