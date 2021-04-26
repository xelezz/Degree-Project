using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public bool isPressed;
    void Start()
    {
        GoToScene();
    }
    private void Update()
    {
        //QuitGame();
    }
    public void GoToScene()
    {
        SceneManager.LoadScene("MainScene");            
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
