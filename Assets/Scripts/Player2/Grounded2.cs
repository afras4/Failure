using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grounded2 : MonoBehaviour
{
    GameObject Player2;
    // Start is called before the first frame update
    void Start()
    {
        Player2 = gameObject.transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.collider.tag=="Ground")
        {
            Player2.GetComponent<MovimientoP2>().isGrounded=true;
        }
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        if(other.collider.tag=="Ground")
        {
            Player2.GetComponent<MovimientoP2>().isGrounded=false;
        }
    }
}
