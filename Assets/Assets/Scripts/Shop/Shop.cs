using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    [SerializeField]
    private GameObject _shopPanel;
    [SerializeField]
    private Image _selectionImg;
    public Player player;
    private int itemCost;
    private int itemNo;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            player = collision.transform.GetComponent<Player>();
            if (player != null)
            {

                UIManager.Instance.OpenShop(player.gems);
            }
            _shopPanel.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            _shopPanel.SetActive(false);
        }
    }
    public void ItemSelection(int selectNo)
    {
        switch (selectNo)
        {
            case 0:
                UIManager.Instance.SelectedShopItem(105f);
                itemCost = 200;
                itemNo = 0;
                break;
            case 1:
                UIManager.Instance.SelectedShopItem(-2f);
                itemCost = 400;
                itemNo = 1;
                break;
            case 2:
                UIManager.Instance.SelectedShopItem(-102f);
                itemCost = 1000;
                itemNo = 2;

                break;

            default:
                UIManager.Instance.SelectedShopItem(105f);
                itemCost = 200;
                break;
        }
    }
    public void BuyItem()
    {
        if (player.gems>=itemCost)
        {
            UIManager.Instance.WriteGemCount(player.gems);
            if (itemNo == 2)
            {
                GameManager.Instance.HasKey = true;
            }
           player.gems= player.gems-itemCost;
            _shopPanel.SetActive(false);
            Debug.Log("Buy is Success");
        }
        else
        {
            Debug.Log("Buy is Failed");
            _shopPanel.SetActive(false);
        }
    }
}
