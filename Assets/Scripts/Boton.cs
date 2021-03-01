using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boton : MonoBehaviour
{
    public GameObject [] posicionesrojo;
    public GameObject [] posicionesazul;

    void Start()
    {
        spawn();
    }
    void Update()
    {
    }
    public void spawn()
    {
        int ran=Random.Range(1, 3);
        int ran2=Random.Range(1,3);
        Debug.Log("  " + ran);
        Debug.Log("  " + ran2);
        switch(ran)
        {
            case 1:
            posicionesrojo[0].SetActive(true);
            break;
            
            case 2:
            posicionesrojo[1].SetActive(true);
            break;
            /*
            case 3:
            gameObject.transform.position= posiciones[2].transform.position;
            break;

            case 4:
            gameObject.transform.position= posiciones[3].transform.position;
            break;
            */
        }
        switch(ran2)
        {
            case 1:
             posicionesazul[0].SetActive(true);
            break;
            
            case 2:
             posicionesazul[1].SetActive(true);
            break;
        }
    }
}
