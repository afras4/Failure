using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathObject : MonoBehaviour
{
    public int color;
    public GameObject player1;
    public GameObject player2;
    public Transform initPos1;
    public Transform initPos2;  
    public int pointsP1;
    public int pointsP2;

    void Start() {
        color = 0;
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            color = color + 1;
        }
        if(color>2){
            color = 0;
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(color == 1){
        if(other.gameObject.tag == "Player1"){
            pointsP1 = pointsP1 + 1;
            player1.transform.position = initPos1.position;
            
        }    
        }
        if(color == 2){
        if(other.gameObject.tag == "Player2"){
            pointsP2 = pointsP2 + 1;
            player2.transform.position = initPos2.position;

        }    
        }
    }
}
