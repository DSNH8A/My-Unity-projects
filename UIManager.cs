using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    private static UIManager instance;
    public static UIManager Instance
    {
        get
        {
            if (instance == null)
            {
                Debug.Log("Error");
            }

            return instance;
        }
    }
    public GameObject boots;
    public Text gemText;
    public Text hudGemText;
    public Image selectionImage;
    public GameObject keyToCastleButton;
    public GameObject bootsOfFlight;
    public GameObject flameSword;
    public Image[] lifeBars = new Image[4];

    public void OpenShop(int gems)
    {
        gemText.text = "" + gems + "G";
    }

    public void DiamondDisplay(int diamond)
    {
        hudGemText.text = "" + diamond;   
    }

    public void UpdateShopSelection(int yPos)
    {
        selectionImage.rectTransform.anchoredPosition = new Vector2(selectionImage.rectTransform.anchoredPosition.x, yPos);   
    }

    public void UpdateLives(int livesRemaining)
    {
        for (int i = 0; i <= livesRemaining; i++)
        {
            if (i == livesRemaining)
            {
                lifeBars[i].enabled = false;   
            }
        }
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    private void Awake()
    {
        instance = this;
        boots.SetActive(false);
    }

    public void Boots()
    {
        if (GameManager.Instance.hasBoots == true)
        { 
            boots.SetActive(true);
        }
    }

    public void OnOff()
    {
        if (GameManager.Instance.hasBoots == true)
        {
            GameManager.Instance.hasBoots = false;
        }

        else 
        {
            GameManager.Instance.hasBoots = true;
        }
    }

    void Update()
    {
        Boots();   
    }
}
