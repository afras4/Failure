using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public DeathObject deathObject;
    public int colorButton;

    private void OnCollisionEnter2D(Collision2D other) {
        if(colorButton == 1){
        if(other.gameObject.tag == "Player1"){
            deathObject.color = 1;
            this.gameObject.SetActive(false);
        }    
        }
        if(colorButton == 2){
        if(other.gameObject.tag == "Player2"){
            deathObject.color = 2;
            this.gameObject.SetActive(false);  
        }
        }
    }
}
