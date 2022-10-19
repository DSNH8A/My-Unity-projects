using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopKeeper : MonoBehaviour
{
    [SerializeField]
    private GameObject shop;
    public int currentSelectedItem;
    public int currentItemCost;
    private Player player;

    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        { 
            shop.SetActive(true);
             player = other.GetComponent<Player>();
            UIManager.Instance.OpenShop(player.diamondCount);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            shop.SetActive(false);
        }
    }

    public void SelectItem(int item)
    {
       
        Debug.Log("SelectedItem " + item);
            
        switch (item)
        {
            case 0:
                UIManager.Instance.UpdateShopSelection(71);
                currentSelectedItem = 0;
                currentItemCost = 200;
                break;
            case 1:
                UIManager.Instance.UpdateShopSelection(-27);
                currentItemCost = 400;
                currentSelectedItem = 1;
                break;
            case 2:
                UIManager.Instance.UpdateShopSelection(-111);
                currentSelectedItem = 2;
                currentItemCost = 100;
                break;
        }     
    }

    public void BuyItem()
    {
        

        if (player.diamondCount >= currentItemCost)
        {
            player.diamondCount -= currentItemCost;
            Debug.Log("Purchased" + currentSelectedItem);
            Debug.Log("Remaining Gems: " + player.diamondCount);
            if (currentSelectedItem == 2)
            {
                GameManager.Instance.HasKeyToCastle = true;
                if (GameManager.Instance.HasKeyToCastle == true)
                {
                    UIManager.Instance.keyToCastleButton.SetActive(false);   
                }
            }

            if (currentSelectedItem == 1)
            {
                GameManager.Instance.hasFlameSword = true;
                Debug.Log("FlameSword aquired");
                if (GameManager.Instance.hasFlameSword == true)
                {
                    UIManager.Instance.flameSword.SetActive(false);  
                }
            }

            if (currentSelectedItem == 0)
            {
                GameManager.Instance.hasBoots = true;
                if (GameManager.Instance.hasBoots == true)
                {
                    UIManager.Instance.bootsOfFlight.SetActive(false);   
                }
            }
        }
        else 
        {
            Debug.Log("You dont have enough gems buddy. Shop is closed for you!!!");
            shop.SetActive(false);  
        }
    }

    void Update()
    {
        UIManager.Instance.OpenShop(player.diamondCount);   
    }
}
