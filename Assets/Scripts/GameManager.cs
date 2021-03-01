using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Prime31.TransitionKit;

public class GameManager : MonoBehaviour
{
    public Texture2D maskTexture;
    public Texture2D maskTexture2;
    public Text txtPointsP1;
    public Text txtPointsP2;
    public Text txtTime;
    public Transform initPos1;
    public Transform initPos2; 

    public GameObject player1;
    public GameObject player2;
    public GameObject PreGameButtons;
    public GameObject Number1;
    public GameObject Number2;
    public GameObject Number3;
    public GameObject TheTime;
    public GameObject Players;
    public GameObject DownSpike;
    public GameObject TopSpike;
    public GameObject RightSpike;
    public GameObject LeftSpike;
    public GameObject[] LeButtons;

    public bool move1;
    public bool move2;
    public bool move3;
    public bool move4;
    public bool gameStart;
    public bool timerIsRunning = false;
    public int color;
    public int spikeNumber;
    public int pointsP1;
    public int pointsP2;
    private float startTime;
    public float timeRemaining = 180;
    float dirY, moveSpeed = 0.08f;
    float dirX, moveSpeed1 = 0.08f;
    public AudioSource fightMusic;
    public AudioSource oneSound;
    public AudioSource twoSound;
    public AudioSource threeSound;
    public AudioSource oneVoice;
    public AudioSource twoVoice;
    public AudioSource threeVoice;
    public AudioSource goGogo;
    public AudioSource go;
    public AudioSource ready;
    public AudioSource explode;
    
    
    // Start is called before the first frame update
    void Start()
    {
        gameStart=false;
        move1=true;
        move2=true;
        move3=true;
        move4=true;
        PreGameButtons.gameObject.SetActive(true);
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
        timerIsRunning=true;
        if(spikeNumber == 1 || spikeNumber == 2){
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

        if(spikeNumber == 3 || spikeNumber == 4 || spikeNumber == 5){
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

        if(spikeNumber == 6){
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

        if(spikeNumber == 7){
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

        //string minutes = ((int) t /60).ToString();
        //string seconds = (t % 60).ToString("f0");
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                Debug.Log("Time has run out!");
                timeRemaining = 0;
                timerIsRunning = false;
                if(pointsP1>pointsP2)
                {
                    SceneManager.LoadScene("VictoriaMono");	
                }
                else
                {
                    SceneManager.LoadScene("VictoriaPato");
                }
            }
        }

        //txtTime.text = minutes + ":" + seconds; 
        }
        if(pointsP1>=5)
        {
            SceneManager.LoadScene("VictoriaMono");	
        }
        if(pointsP2>=5)
        {
            SceneManager.LoadScene("VictoriaPato");	
        }
        txtPointsP1.text = "Manueh: " + pointsP1;
        txtPointsP2.text = "Antonioh: " + pointsP2;
    }
    IEnumerator GameCount()
    {
        yield return new WaitForSeconds(1f);
        Number3.gameObject.SetActive(true);
        threeSound.Play();
        threeVoice.Play();
        yield return new WaitForSeconds(1);
        Number3.gameObject.SetActive(false);
        Number2.gameObject.SetActive(true);
        twoSound.Play();
        twoVoice.Play();
        yield return new WaitForSeconds(1);
        Number2.gameObject.SetActive(false);
        Number1.gameObject.SetActive(true);
        oneSound.Play();
        oneVoice.Play();
        yield return new WaitForSeconds(1);
        Number1.gameObject.SetActive(false);
        PreGameButtons.gameObject.SetActive(false);
        TheTime.gameObject.SetActive(true);
        Players.gameObject.SetActive(true);
        startTime = Time.time;
        gameStart = true;
        fightMusic.Play();
        goGogo.Play();
        StartCoroutine(SpikesTurn());
    }
    IEnumerator SpikesTurn()
    {
        spikeNumber = Random.Range(1,8);
        yield return new WaitForSeconds(8f);
        StartCoroutine(SpikesTurn());
        yield break;
    }
     void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60); 
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        txtTime.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
    public void onResetSet1(){
    pointsP1 = pointsP1 + 1;
    var mask = new ImageMaskTransition()
			{
				maskTexture = maskTexture,
				backgroundColor = new Color(0.2156863f,0.5882353f,0.7333333f,1),
			};
			TransitionKit.instance.transitionWithDelegate( mask );
    StartCoroutine(Respawn());
    }
    public void onResetSet2(){
    pointsP2 = pointsP2 + 1;
    var mask = new ImageMaskTransition()
			{
				maskTexture = maskTexture2 ,
				backgroundColor = new Color(0.8705883f,0.3764706f,0.2588235f,1),
			};
			TransitionKit.instance.transitionWithDelegate( mask );
    StartCoroutine(Respawn());
    }
    IEnumerator Respawn()
        {
        explode.Play();
        yield return new WaitForSeconds(0.9f);
        ready.Play();
        for(int i = 0; i < LeButtons.Length; i++)
        {
            LeButtons[i].SetActive(false);
        }
        yield return new WaitForSeconds(0.9f);
        go.Play();
        color = 0;
        player1.transform.position = initPos1.position;
        player2.transform.position = initPos2.position;
    }
}
