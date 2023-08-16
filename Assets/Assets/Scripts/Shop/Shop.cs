using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField]
    private GameObject _shopPanel;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag=="Player")
        {
            _shopPanel.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.tag=="Player")
        {
            _shopPanel.SetActive(false);
        }
    }
}
