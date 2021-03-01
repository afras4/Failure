using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public DeathObject[] deathObject;
    public GameObject [] botones;
    public GameObject[] activar;
    public int colorButton;

    private void OnCollisionEnter2D(Collision2D other) {
        if(colorButton == 1){
        if(other.gameObject.tag == "Player1"){
            deathObject[0].color = 1;
            deathObject[1].color = 1;
            deathObject[2].color = 1;
            deathObject[3].color = 1;
            
            activar[1].SetActive(true);
            activar[3].SetActive(true);
            activar[5].SetActive(true);
            activar[7].SetActive(true);

            botones[0].SetActive(false);
            botones[1].SetActive(false);
            botones[2].SetActive(false);
            this.gameObject.SetActive(false);
            
        }    
        }
        if(colorButton == 2){
        if(other.gameObject.tag == "Player2"){
            deathObject[0].color = 2;
            deathObject[1].color = 2;
            deathObject[2].color = 2;
            deathObject[3].color = 2;

            activar[0].SetActive(true);
            activar[2].SetActive(true);  
            activar[4].SetActive(true);  
            activar[6].SetActive(true);

            botones[0].SetActive(false);
            botones[1].SetActive(false);
            botones[2].SetActive(false);
            this.gameObject.SetActive(false);
              
        }
        }
    }
}
