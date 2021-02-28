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
    float dirY, moveSpeed = 0.08f;
    public GameObject Number3;
    public GameObject Number2;
    public GameObject Number1;
    public GameObject TheTime;
    public GameObject Players;
    public GameObject DownSpike;
    public bool gameStart;
    public bool move1;

    // Start is called before the first frame update
    void Start()
    {
        gameStart=false;
        move1=true;
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
        if(DownSpike.transform.position.y > 0.11f){
            move1 = false;
        }
        if(DownSpike.transform.position.y < -0.05f){
            move1 = true;
        }
        if(move1){
            DownSpike.transform.position = new Vector2(DownSpike.transform.position.x , DownSpike.transform.position.y + moveSpeed * Time.deltaTime);
        }else{
            DownSpike.transform.position = new Vector2(DownSpike.transform.position.x , DownSpike.transform.position.y - moveSpeed * Time.deltaTime);
        }

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
        yield return new WaitForSeconds(1.5f);
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
