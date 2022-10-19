using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
    {
    [SerializeField]
    private Text scoreText;
    [SerializeField]
    private Image livesImage;
    [SerializeField]
    private Sprite[] livesprites;
    [SerializeField]
    private Text gameOverText;
    private bool flicker = true;
    private int flickerCounter;
    [SerializeField]
    private Text restartText;
    private string input;
    [SerializeField]
    private GameManager gameManager;
    public GameObject gameoverButton;

    void Start()
    {
        scoreText.text = "Score " + 0;
        GameObject.Find("Game_Manager").GetComponent<GameManager>();
    }

   public void UpdateScore(int playerscore)
   {
        scoreText.text = "Score " + playerscore.ToString(); 
   }

   public void UpdateLives(int currentLives)
   {
        livesImage.sprite = livesprites[currentLives];
        if (currentLives == 0)   
        {
            gameoverButton.SetActive(true);
            gameManager.GameOver();
            restartText.gameObject.SetActive(true);
            gameOverText.gameObject.SetActive(true);
            StartCoroutine(TextFlickerRoutine());
            IEnumerator TextFlickerRoutine()
            {

                while (flicker == true)
                {
                    yield return new WaitForSeconds(0.1f);
                    gameOverText.gameObject.SetActive(false);
                    flickerCounter += 1;
                    yield return new WaitForSeconds(0.1f);
                    gameOverText.gameObject.SetActive(true);
                    flickerCounter += 1;
                    /*
                     * gameOverText.Text = "GameOver"
                     * yield return new WaitForSeconds(0.5f)
                     * gameOverText.Text = ""
                     * yiled return new WaitForSeconds(0.5f)
                     */


                    if (flickerCounter == 2000)
                    {
                        break;   
                    }

                }
                

            }

        }
   }

}
