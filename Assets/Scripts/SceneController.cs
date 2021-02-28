using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Prime31.TransitionKit;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public GameObject panel;
    public GameObject main;
    void Start()
    {
        panel.SetActive(false);
        main.SetActive(true);
    }
    void Update() {
    if(Input.GetKeyDown(KeyCode.Space ) )
		{
			var slices = new TriangleSlicesTransition()
			{
				nextScene = SceneManager.GetActiveScene().buildIndex == 1 ? 2 : 1,
				divisions = Random.Range( 2, 6 )
			};
			TransitionKit.instance.transitionWithDelegate( slices );
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
			var slices = new TriangleSlicesTransition()
			{
				nextScene = SceneManager.GetActiveScene().buildIndex == 1 ? 2 : 1,
				divisions = Random.Range( 2, 6 )
			};
			TransitionKit.instance.transitionWithDelegate( slices );
		}
    
}
