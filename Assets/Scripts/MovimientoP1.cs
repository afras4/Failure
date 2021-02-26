using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoP1 : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb2d;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D> ();
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate()
    {
        Vector3 movimiento= new Vector3(Input.GetAxis("Horizontal"),0f,0f);
        transform.position += movimiento*speed*Time.deltaTime;
    }
    void Jump()
    {
        if(Input.GetButtonDown("Jump"))
        {
            rb2d.AddForce(new Vector2(0f,5f), ForceMode2D.Impulse);
        }
    }
    
}
