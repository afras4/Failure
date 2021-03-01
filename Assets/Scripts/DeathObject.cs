using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Prime31.TransitionKit;

public class DeathObject : MonoBehaviour
{
    public GameManager gameManager;
    SpriteRenderer m_SpriteRenderer;

    void Start() {
        gameManager.color = 0;
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        m_SpriteRenderer.color = Color.white;
    }
    void Update()
    {
        if(gameManager.color == 0){
        m_SpriteRenderer.color = Color.white;
        }
        if(gameManager.color == 1){
        m_SpriteRenderer.color = new Color(0.2156863f,0.5882353f,0.7333333f,1);
        }
        if(gameManager.color == 2){
        m_SpriteRenderer.color = new Color(0.8705883f,0.3764706f,0.2588235f,1);
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(gameManager.color == 1){
        if(other.gameObject.tag == "Player1"){
            gameManager.onResetSet1();
        }    
        }
        if(gameManager.color == 2){
        if(other.gameObject.tag == "Player2"){
            gameManager.onResetSet2();
        }    
        }
    }
}
