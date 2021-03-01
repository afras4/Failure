using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject [] botones;
    public GameObject[] activar;
    public int colorButton;
    public AudioSource pressButton;

    //botonesdecolor
    private void OnCollisionEnter2D(Collision2D other) {
        if(colorButton == 1){
        if(other.gameObject.tag == "Player1"){
            pressButton.Play();
            gameManager.color = 1;

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
            pressButton.Play();
            gameManager.color = 2;

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
