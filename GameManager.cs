using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private bool isGameOver;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && isGameOver == true)
        {
            SceneManager.LoadScene(1);   
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();   
        }
    }
    public void GameOver()
    {
        isGameOver = true;   
    }

    public void ReStart()
    {
        SceneManager.LoadScene(1);
    }
}
