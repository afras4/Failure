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
    public GameObject Number3;
    public GameObject Number2;
    public GameObject Number1;
    public GameObject TheTime;
    public GameObject Players;
    public bool gameStart;

    // Start is called before the first frame update
    void Start()
    {
        gameStart=false;
        
        Players.gameObject.SetActive(false);
        Number3.gameObject.SetActive(false);
        Number2.gameObject.SetActive(false);
        Number1.gameObject.SetActive(false);
        TheTime.gameObject.SetActive(false);
        StartCoroutine(GameCount());
    }

    // Update is called once per frame
    void Update()
    {
        if(gameStart == true){
        float t = Time.time - startTime;
        

        string minutes = ((int) t /60).ToString();
        string seconds = (t % 60).ToString("f0");

        txtTime.text = minutes + ":" + seconds; 
        }
        txtPointsP1.text = "Manueh: " + deathObject.pointsP1;
        txtPointsP2.text = "Antonioh: " + deathObject.pointsP2;
    }
    IEnumerator GameCount()
    {
        Number3.gameObject.SetActive(true);
        yield return new WaitForSeconds(1);
        Number3.gameObject.SetActive(false);
        Number2.gameObject.SetActive(true);
        yield return new WaitForSeconds(1);
        Number2.gameObject.SetActive(false);
        Number1.gameObject.SetActive(true);
        yield return new WaitForSeconds(1);
        Number1.gameObject.SetActive(false);
        TheTime.gameObject.SetActive(true);
        Players.gameObject.SetActive(true);
        startTime = Time.time;
        gameStart = true;
    }
}
