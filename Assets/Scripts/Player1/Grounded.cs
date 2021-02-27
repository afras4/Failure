using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grounded : MonoBehaviour
{
    GameObject Player1;
    // Start is called before the first frame update
    void Start()
    {
        Player1 = gameObject.transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.collider.tag=="Ground")
        {
            Player1.GetComponent<MovimientoP1>().isGrounded=true;
        }
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        if(other.collider.tag=="Ground")
        {
            Player1.GetComponent<MovimientoP1>().isGrounded=false;
        }
    }
}
