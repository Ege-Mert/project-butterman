using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    public GameObject gameOverUI;
    public GameObject gameWonUI;
    void Start()
    {
    }

    void Update()
    {
        if(gameOverUI.activeInHierarchy || gameWonUI.activeInHierarchy)
        { Cursor.visible = true;
         Cursor.lockState = CursorLockMode.None;
        }
        else
        {
         Cursor.visible = true;       
        }
    }
    public void gameOver(){
        gameOverUI.SetActive(true);
    }
    public void gameWon(){
        gameWonUI.SetActive(true);
    }
    public void restart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void quit(){
        Application.Quit();
    }
}
