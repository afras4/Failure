using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoP1 : MonoBehaviour
{
    public float speed;
    public float salto;
    public bool isFlipped;
    private Animator anim;
    public AudioSource walk;
    public AudioSource hurt;
    public AudioSource jump;
    public GameManager gameManager;
    
    private Rigidbody2D rb2d;
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
        Vector3 movimiento= new Vector3(Input.GetAxis("Horizontal1"),0f,0f); 
        transform.position += movimiento*speed*Time.deltaTime;
        if (Input.GetKey (KeyCode.D)) 
		{
			isFlipped = false;
			transform.localScale = new Vector3 (3.669608f, 3.669608f, 0f);
		}
        if (Input.GetKey (KeyCode.A)) 
		{
			isFlipped = true;
			transform.localScale = new Vector3 (-3.669608f, 3.669608f, 0f);
		}
        if(Input.GetAxis("Horizontal1")!=0)
        {
            anim.Play("MonoRun");
        }
        else
        {
            anim.Play("MonoIddle");
        }
        if(gameManager.pointsP1<gameManager.pointsP2){
            speed = 3f;
            salto = 4f;
        }else{
            speed = 2f;
            salto = 3f;
        }


    }
    void Jump()
    {
        if(Input.GetButtonDown("Jump1") && Mathf.Abs(rb2d.velocity.y)<0.001f)
        {
            jump.Play();
            rb2d.AddForce(new Vector2(0f,salto), ForceMode2D.Impulse);
            
        }
    }
        private void OnCollisionEnter2D(Collision2D other)
    {
        if(isFlipped == false){
        if (other.gameObject.tag == "Player2")
        {
            hurt.Play();
            rb2d.AddForce(new Vector2(-4, 4), ForceMode2D.Impulse);
        }
        }
        if(isFlipped == true){
        if (other.gameObject.tag == "Player2")
        {
            hurt.Play();
            rb2d.AddForce(new Vector2(4, 4), ForceMode2D.Impulse);
        }
        }
    }
}
