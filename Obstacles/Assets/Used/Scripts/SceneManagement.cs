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
        GoToStart();
    }
    private void Update()
    {
        QuitGame();
    }
    public void GoToScene()
    {
        SceneManager.LoadScene("MainScene");
    }
    public void GoToStart()
    {
        SceneManager.LoadScene("StartMenu");
    }
    public void QuitGame()
    {
        Application.Quit();
    }

}
