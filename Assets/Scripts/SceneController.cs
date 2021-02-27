using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
        Debug.Log("sceneName to load: " + scenename);
        SceneManager.LoadScene(scenename);
    }
}
