using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private static UIManager _instance;
    public static UIManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.Log("UIManager is NULL");
            }
            return _instance;
        }
    }
    public Text gemCountTextForShop;
    public Text gemCountText;
    public Image SelectionImg;
    public void OpenShop(int gemCount)
    {
        gemCountTextForShop.text = " "+gemCount+"G";
    }
    
    public void SelectedShopItem(float y)
    {
        SelectionImg.rectTransform.anchoredPosition = new Vector2(76.4f, y);
    }
    public void WriteGemCount(int gemCount)
    {
        gemCountText.text = gemCount.ToString();
    }
    public Image[] healthImages;
    public void UpdateLives(int currentLives)
    {
        switch (currentLives)
        {
            case 0: healthImages[3].gameObject.SetActive(false); break;
            case 1: healthImages[2].gameObject.SetActive(false); break;
            case 2: healthImages[1].gameObject.SetActive(false); break;
            case 3: healthImages[0].gameObject.SetActive(false); break;
            default:
                break;
        }
    }
    private void Awake()
    {
        _instance = this;
    }
}
