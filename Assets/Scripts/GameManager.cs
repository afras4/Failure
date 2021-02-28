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
    float dirX, moveSpeed1 = 0.08f;
    public GameObject Number3;
    public GameObject Number2;
    public GameObject Number1;
    public GameObject TheTime;
    public GameObject Players;
    public GameObject DownSpike;
    public GameObject TopSpike;
    public GameObject RightSpike;
    public GameObject LeftSpike;
    public int spikeNumber;
    public bool move1;
    public bool move2;
    public bool move3;
    public bool move4;
    public bool gameStart;
    
    // Start is called before the first frame update
    void Start()
    {
        gameStart=false;
        move1=true;
        move2=true;
        move3=true;
        move4=true;
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
        
        if(spikeNumber == 1){
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
        }

        if(spikeNumber == 2){
        if(TopSpike.transform.position.y > 2.032f){
            move2 = true;
        }
        if(TopSpike.transform.position.y < 1.873f){
            move2 = false;
        }
        if(move2){
            TopSpike.transform.position = new Vector2(TopSpike.transform.position.x , TopSpike.transform.position.y - moveSpeed * Time.deltaTime);
        }else{
            TopSpike.transform.position = new Vector2(TopSpike.transform.position.x , TopSpike.transform.position.y + moveSpeed * Time.deltaTime);
        }
        }

        if(spikeNumber == 3){
        if(LeftSpike.transform.position.x > -0.002f){
            move3 = false;
        }
        if(LeftSpike.transform.position.x < -0.161f){
            move3 = true;
        }
        if(move3){
            LeftSpike.transform.position = new Vector2(LeftSpike.transform.position.x + moveSpeed1 * Time.deltaTime, LeftSpike.transform.position.y);
        }else{
            LeftSpike.transform.position = new Vector2(LeftSpike.transform.position.x - moveSpeed1 * Time.deltaTime, LeftSpike.transform.position.y);
        }
        }

        if(spikeNumber == 4){
        if(RightSpike.transform.position.x > 3.36f){
            move4 = true;
        }
        if(RightSpike.transform.position.x < 3.2f){
            move4 = false;
        }
        if(move4){
            RightSpike.transform.position = new Vector2(RightSpike.transform.position.x - moveSpeed1 * Time.deltaTime, RightSpike.transform.position.y);
        }else{
            RightSpike.transform.position = new Vector2(RightSpike.transform.position.x + moveSpeed1 * Time.deltaTime, RightSpike.transform.position.y);
        }
        }

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
        StartCoroutine(SpikesTurn());
    }
    IEnumerator SpikesTurn()
    {
        spikeNumber = Random.Range(1,4);
        yield return new WaitForSeconds(8f);
        StartCoroutine(SpikesTurn());
        yield break;
    }
}
