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
    public Text gemCountText;
    public Image SelectionImg;
    public void OpenShop(int gemCount)
    {
        gemCountText.text = " "+gemCount+"G";
    }
    
    public void SelectedShopItem(float y)
    {
        SelectionImg.rectTransform.anchoredPosition = new Vector2(76.4f, y);
    }
    private void Awake()
    {
        _instance = this;
    }
}
