﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Prime31.TransitionKit;

public class DeathObject : MonoBehaviour
{
    public int color;
    public GameObject player1;
    public GameObject player2;
    public Transform initPos1;
    public Transform initPos2;  
    public int pointsP1;
    public int pointsP2;
    public Texture2D maskTexture;
    public Texture2D maskTexture2;
    SpriteRenderer m_SpriteRenderer;

    void Start() {
        color = 0;
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        m_SpriteRenderer.color = Color.white;
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            color = color + 1;
        }
        if(color>2){
            color = 0;
        }
        if(color == 1){
        m_SpriteRenderer.color = new Color(0.2156863f,0.5882353f,0.7333333f,1);
        }
        if(color == 2){
        m_SpriteRenderer.color = new Color(0.8705883f,0.3764706f,0.2588235f,1);
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(color == 1){
        if(other.gameObject.tag == "Player1"){
            pointsP1 = pointsP1 + 1;

			var mask = new ImageMaskTransition()
			{
				maskTexture = maskTexture,
				backgroundColor = new Color(0.2156863f,0.5882353f,0.7333333f,1),
			};
			TransitionKit.instance.transitionWithDelegate( mask );
            StartCoroutine(Respawn());
        }    
        }
        if(color == 2){
        if(other.gameObject.tag == "Player2"){
            pointsP2 = pointsP2 + 1;

            var mask = new ImageMaskTransition()
			{
				maskTexture = maskTexture2 ,
				backgroundColor = new Color(0.8705883f,0.3764706f,0.2588235f,1),
			};
			TransitionKit.instance.transitionWithDelegate( mask );
            StartCoroutine(Respawn());
        }    
        }
        
        IEnumerator Respawn()
        {
        yield return new WaitForSeconds(1.8f);
        player1.transform.position = initPos1.position;
        player2.transform.position = initPos2.position;
        }
    }
}
