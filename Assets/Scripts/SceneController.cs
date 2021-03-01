using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using Prime31.TransitionKit;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public GameObject panel;
    public GameObject main;
    public GameObject p1;
    public GameObject p2;
    public bool move1;
    public bool move2;
    float dirY, moveSpeed = 0.15f;
    void Start()
    {
        StartCoroutine(endVideo());
        panel.SetActive(false);
        main.SetActive(true);
    }
    void Update() {
    if(Input.GetKeyDown(KeyCode.Space ) )
		{
			var slices = new VerticalSlicesTransition()
			{
				nextScene = SceneManager.GetActiveScene().buildIndex == 1 ? 2 : 1,
				divisions = Random.Range( 2, 10 )
			};
			TransitionKit.instance.transitionWithDelegate( slices );
		}

    if(p1.transform.position.y > 0.15f){
            move1 = false;
        }
        if(p1.transform.position.y < -0.15f){
            move1 = true;
        }
        if(move1){
            p1.transform.position = new Vector2(p1.transform.position.x , p1.transform.position.y + moveSpeed * Time.deltaTime);
        }else{
            p1.transform.position = new Vector2(p1.transform.position.x , p1.transform.position.y - moveSpeed * Time.deltaTime);
        }

    if(p2.transform.position.y > 0.15f){
            move2 = false;
        }
        if(p2.transform.position.y < -0.15f){
            move2 = true;
        }
        if(move2){
            p2.transform.position = new Vector2(p2.transform.position.x , p2.transform.position.y + moveSpeed * Time.deltaTime);
        }else{
            p2.transform.position = new Vector2(p2.transform.position.x , p2.transform.position.y - moveSpeed * Time.deltaTime);
        }
    }
    public void Credits(){
        panel.SetActive(true);
        main.SetActive(false);
    }
    public void Back(){
        panel.SetActive(false);
        main.SetActive(true);
    }
    public void LoadScene(string scenename)
		{
			var slices = new VerticalSlicesTransition()
			{
				nextScene = SceneManager.GetActiveScene().buildIndex == 1 ? 2 : 1,
				divisions = Random.Range( 2, 10 )
			};
			TransitionKit.instance.transitionWithDelegate( slices );
		}
    public void LoadSceneWin(string scenename)
		{
			var slices = new VerticalSlicesTransition()
			{
				nextScene = SceneManager.GetActiveScene().buildIndex == 0 ? 1 : 0,
				divisions = Random.Range( 2, 10 )
			};
			TransitionKit.instance.transitionWithDelegate( slices );
		}
    IEnumerator endVideo()
    {
        yield return new WaitForSeconds(27f);
        var slices = new VerticalSlicesTransition()
			{
				nextScene = SceneManager.GetActiveScene().buildIndex == 1 ? 2 : 1,
				divisions = Random.Range( 2, 10 )
			};
			TransitionKit.instance.transitionWithDelegate( slices );
    }
}
