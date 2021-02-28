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
        	var squares = new SquaresTransition()
			{
				nextScene = SceneManager.GetActiveScene().buildIndex == 1 ? 2 : 1,
				duration = 2.0f,
				squareSize = new Vector2( 5f, 4f ),
				smoothness = 0.0f
			};
			TransitionKit.instance.transitionWithDelegate( squares );
    }
    
}
