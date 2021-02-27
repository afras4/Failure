using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public DeathObject deathObject;
    public Text txtPointsP1;
    public Text txtPointsP2;
    public Text txtTime;
    private float startTime;

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        float t = Time.time - startTime;

        string minutes = ((int) t /60).ToString();
        string seconds = (t % 60).ToString("f0");

        txtTime.text = minutes + ":" + seconds; 
        
        txtPointsP1.text = "PuntosP1: " + deathObject.pointsP1;
        txtPointsP2.text = "PuntosP2: " + deathObject.pointsP2;
    }
}
