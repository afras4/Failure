﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoP2 : MonoBehaviour
{
    public float speed;
    public float salto;
    public bool isFlipped;
    private Animator anim;
    public AudioSource walk;
    public AudioSource hurt;
    public AudioSource jump;
    public GameObject particles1;
    public GameObject particles2;

    private Rigidbody2D rb2d;

    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        isFlipped = false;
        rb2d = GetComponent<Rigidbody2D> ();
        anim = GetComponent<Animator> ();
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate()
    {
        Jump();
        Vector3 movimiento= new Vector3(Input.GetAxis("Horizontal2"),0f,0f);
        transform.position += movimiento*speed*Time.deltaTime;
        if (Input.GetKey (KeyCode.LeftArrow)) 
		{	
            particles1.SetActive(true);
            isFlipped = false;
			transform.localScale = new Vector3 (3.669608f, 3.669608f, 0f);
		}
        if (Input.GetKey (KeyCode.RightArrow)) 
		{	
            particles1.SetActive(true);
            isFlipped = true;
			transform.localScale = new Vector3 (-3.669608f, 3.669608f, 0f);
		}
        if(Input.GetAxis("Horizontal2")!=0)
        {
            anim.Play("PatoRun");
        }
        else
        {
            particles1.SetActive(false);
            anim.Play("PatoIddle");
        }
        if(gameManager.pointsP1>gameManager.pointsP2){
            particles2.SetActive(true);
            speed = 3f;
            salto = 4f;
            if(Input.GetAxis("Horizontal1")!=0)
            {
                particles2.SetActive(true);
            }
            else
            {
                particles2.SetActive(false);
            }
        }else{
            particles2.SetActive(false);
            speed = 2f;
            salto = 3f;
        }
    }
    void Jump()
    {
        if(Input.GetButtonDown("Jump2") && Mathf.Abs(rb2d.velocity.y)<0.001f)
        {
            jump.Play();
            rb2d.AddForce(new Vector2(0f,salto), ForceMode2D.Impulse);
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(isFlipped == false){
        if (other.gameObject.tag == "Player1")
        {
            //hurt.Play();
            rb2d.AddForce(new Vector2(4, 4), ForceMode2D.Impulse);
        }
        }
        if(isFlipped == true){
        if (other.gameObject.tag == "Player1")
        {
            //hurt.Play();
            rb2d.AddForce(new Vector2(-4, 4), ForceMode2D.Impulse);
        }
        }
    }
}
